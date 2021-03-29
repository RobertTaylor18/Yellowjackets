using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float bulletSpeed = 1;

    public float dist = 50;

    public Rigidbody bullet;
    public GameObject originPoint; //from where the bullet comes out, select the "Shooting_Point"
    public GameObject player;

    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, originPoint.transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= dist) 
            Fire();
        //if in range fires
    }
}
