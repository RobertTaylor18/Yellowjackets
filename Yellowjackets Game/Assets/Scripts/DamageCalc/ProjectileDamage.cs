using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int baseDamage;
    public int damageMod;
    public bool isEnemy;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isEnemy == false)
        {
            other.gameObject.GetComponent<Health>().health -= baseDamage * damageMod;
        }
        else if (other.gameObject.tag == "Player" && isEnemy)
        {

        }
    }

}
