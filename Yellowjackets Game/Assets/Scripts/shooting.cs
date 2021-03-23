using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour
{
    public float bulletSpeed = 10;
   

    public float bulletSpeed2 = 10;
    
    
    public Rigidbody bullet;
    public Rigidbody bullet2;
    public Rigidbody missile;
    public Rigidbody cloud;
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
    
    void Fire4()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(missile, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed/5;
    }
    
    void Fire5()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(cloud, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed/10;
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
        else if (Input.GetKeyDown("t"))
        {
            Fire4();
        }
        else if (Input.GetKeyDown("c"))
        {
            Fire5();
        }
    }
}