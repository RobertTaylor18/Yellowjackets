using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour {
    public GameObject player;

    [Header("Stats")]
    public float baseDamage;
    public float damageMod;
    public float damageCalc;

    [Header("Status Effects")]
    public bool burn;
    public bool bleed;
    public bool slow;

    [Space]
    public bool isEnemy;
    public ParticleSystem particle;

    void Start() {
        player = GameObject.FindWithTag("Player");
        damageMod = player.GetComponent<Shooting>().AttackDamageMod;
        damageCalc = baseDamage * damageMod;
        if (player.GetComponentInChildren<Wasabee>() != null) {
            burn = true;
        }
        if (player.GetComponentInChildren<Bumblegum>() != null) {
            slow = true;
        }

    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy" && isEnemy == false) {
            //other.gameObject.GetComponent<Health>().health -= baseDamage * damageMod;
            if (player.GetComponentInChildren<FluxCapacitor>() != null) {
                damageCalc += player.GetComponentInChildren<FluxCapacitor>().fluxDamageMod;
            }

            if (player.GetComponentInChildren<Beeserker>() != null) {
                damageCalc += player.GetComponentInChildren<Beeserker>().beeserkerMod;
            }

            other.gameObject.GetComponent<Health>().OnDamage(damageCalc);

            if (other.GetComponent<StatusEffectManager>() != null && bleed) {
                other.gameObject.GetComponent<StatusEffectManager>().ApplyBleed(4);
            }
            if (other.GetComponent<StatusEffectManager>() != null && burn) {
                other.gameObject.GetComponent<StatusEffectManager>().ApplyBurn(5);
            }
            if (other.GetComponent<StatusEffectManager>() != null && slow) {
                other.gameObject.GetComponent<StatusEffectManager>().ApplySlow(1);
            }
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else if (other.gameObject.tag == "Player" && isEnemy) {
            other.gameObject.GetComponent<PlayerHealth>().OnDamage(damageCalc);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
