using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public Rigidbody bullet;
    public float AttackSpeed;
    private float elapsedTime = 0;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
       // int layerMask = 1 << 6;
       /* if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            defaultWeapon();  
        }*/
        if (Physics.BoxCast(transform.position, new Vector3 (2,2,2) ,  transform.TransformDirection(Vector3.forward), out hit, transform.rotation ,Mathf.Infinity, layerMask))
        {
            defaultWeapon();  
        }
    }

    void defaultWeapon()
    {
        if (Time.time > elapsedTime)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.velocity = transform.forward * 100;

            elapsedTime = Time.time + AttackSpeed;
        }
    }
}
