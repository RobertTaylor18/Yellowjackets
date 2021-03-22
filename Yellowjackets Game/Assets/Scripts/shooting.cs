using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour
{
    public float bulletSpeed = 10;
   

    public float bulletSpeed2 = 10;
    
    
    public Rigidbody bullet;
    public Rigidbody bullet2;
    public GameObject zap;

    

    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    } 
    
    void Fire2()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet2, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed2;
    }
    
    void Fire3()
    {
        GameObject zapClone = Instantiate(zap, transform.position, transform.rotation);
        zapClone.transform.parent = this.gameObject.transform;
        //if not moving forwards detach particle
        //zapClone.transform.parent = null;
    }

    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            Fire();
        }

        else if (Input.GetButton("Fire1"))
        {
            Fire2();
        }
        else if (Input.GetKeyDown("r"))
        {
            Fire3();
        }
    }
}