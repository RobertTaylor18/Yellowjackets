using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int baseDamage;
    public int damageMod;
    public bool isEnemy;
    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isEnemy == false)
        {
            other.gameObject.GetComponent<Health>().health -= baseDamage * damageMod;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player" && isEnemy)
        {
            other.gameObject.GetComponent<Health>().health -= baseDamage * damageMod;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
