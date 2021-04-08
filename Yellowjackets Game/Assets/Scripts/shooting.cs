using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour
{
    public float bulletSpeed = 10;
   

    public float bulletSpeed2 = 10;
    
    
    public Rigidbody bullet;
    public Rigidbody bullet2;
    public Rigidbody missile;
    public Rigidbody shuriken;
    public Rigidbody cloud;
    public GameObject zap;

    public float AttackSpeed;
    public float AttackSpeedBase;
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
    
    void missiles()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(missile, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 25;

            elapsedTime = Time.time + AttackSpeed;
        }
    }

    void shurikens()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(shuriken, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 100;

            elapsedTime = Time.time + AttackSpeed;
        }
    }


    void Update()
    {
        AttackSpeed = AttackSpeedBase / (1 + (AttackSpeedMod / 100));



        if (Input.GetButton("Fire1"))
        {
            if(inventory.weapon == "default")
            {
                AttackSpeedBase = .5f;
                defaultWeapon();
            }
            else if (inventory.weapon == "bomb")
            {
                AttackSpeedBase = 2f;
                bombs();
            }
            else if (inventory.weapon == "missile")
            {
                AttackSpeedBase = 2f;
                missiles();
            }
            else if (inventory.weapon == "shuriken")
            {
                AttackSpeedBase = .4f;
                shurikens();
            }

        }
        

        
    }
}