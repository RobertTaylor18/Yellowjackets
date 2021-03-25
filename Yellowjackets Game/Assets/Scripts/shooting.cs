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

    public float AttackSpeed;
    public float AttackSpeedMod = 0;
    private float elapsedTime = 0;

    public Inventory inventory;



    void defaultWeapon()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 100;

            elapsedTime = Time.time + AttackSpeed;
        }
    }

    void bombs()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet2, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 25;

            elapsedTime = Time.time + AttackSpeed;
        }
    }


    void Update()
    {
        AttackSpeed = 3 / (1 + (AttackSpeedMod / 100));



        if (Input.GetButton("Fire1"))
        {
            if(inventory.weapon == "default")
            {
                
                defaultWeapon();
            }
            else if (inventory.weapon == "bomb")
            {
                bombs();
            }

        }
        

        
    }
}