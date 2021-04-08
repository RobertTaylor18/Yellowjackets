using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [Header("Stats")]
    public int baseDamage;
    public int damageMod;
    public int damageCalc;

    [Header("Status Effects")]
    public bool burn;
    public bool bleed;

    [Space]
    public bool isEnemy;
    public ParticleSystem particle;

    void Start()
    {
        damageCalc = baseDamage * damageMod;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isEnemy == false)
        {
            //other.gameObject.GetComponent<Health>().health -= baseDamage * damageMod;
            other.gameObject.GetComponent<Health>().OnDamage(damageCalc);
            if (other.GetComponent<StatusEffectManager>() != null && bleed)
            {
                other.gameObject.GetComponent<StatusEffectManager>().ApplyBleed(4);
            }
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player" && isEnemy)
        {
            other.gameObject.GetComponent<Health>().health -= damageCalc;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
