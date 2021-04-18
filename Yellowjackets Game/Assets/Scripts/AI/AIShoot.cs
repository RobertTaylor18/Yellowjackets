using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public GameObject player;
    public Rigidbody bullet;
    public float AttackSpeed;
    private float elapsedTime = 0;
    public LayerMask layerMask;

    public RandomFlyer fly;

    public int velocity;
    public float angle;
    public float rotSpeed = 1;
    public float aggroRange = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fly = GetComponent<RandomFlyer>();
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
            //fly.idleSpeed = 10;
            //fly.turnSpeed = 10;
            var targetDir = player.transform.position - transform.position;
            var forward = transform.forward;
            var localTarget = transform.InverseTransformPoint(player.transform.position);

            angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;



                Quaternion toRotation = Quaternion.LookRotation(targetDir, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotSpeed * Time.time);
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
