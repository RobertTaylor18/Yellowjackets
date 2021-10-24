using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public bool isTurret;

    public GameObject player;
    public Fly fly;

    public float aggroRange = 10;
    public float distance;
    public float groundDistance;
    public float speed;
    private Rigidbody rb;
    public int velocity;
    public float angle;
    public float rotSpeed = 1;
    
    public Rigidbody projectile;
    private float elapsedTime = 0;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       // myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        fly = player.GetComponent<Fly>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        groundDistance = Vector3.Distance(fly.groundPoint, transform.position);
        //print(Vector3.Distance(fly.groundPoint, transform.position));
        /* if (Vector3.Distance(player.transform.position, transform.position) > aggroRange && isTurret == false)
         {
             Chase();  
         }
         else
         {
             Shoot();
         }*/

        if (groundDistance > aggroRange && isTurret == false)
        {
            Chase();
        } 
        else if (groundDistance < aggroRange && isTurret == false)
        {
            Shoot();
        }
       
        
        if (distance < aggroRange && isTurret)
        {
            Shoot();
        }
    }

    void Chase()
    {
        //rb.MovePosition((fly.groundPoint + Vector3.up*2) * Time.deltaTime * speed);
        //transform.LookAt(fly.groundPoint);
        // rb.velocity = fly.groundPoint - transform.position* speed;
        transform.position = Vector3.MoveTowards(transform.position, fly.groundPoint, speed*Time.deltaTime);
        if (anim != null)
        {
            anim.SetInteger("state", 1);
        }
    }

    void Shoot()
    {
        if (anim != null)
        {
            anim.SetInteger("state", 2);
        }
        if (Time.time > elapsedTime)
        {
            
            Rigidbody bulletClone = (Rigidbody)Instantiate(projectile, transform.position, transform.rotation);
            if (isTurret)
            {
                bulletClone.velocity = transform.forward* 70;
                elapsedTime = Time.time + 0.3f;
            }
            else
            {
                bulletClone.velocity = transform.up * 2;
                elapsedTime = Time.time + 1;
            }
        }
        
    }



    void FixedUpdate()
    {

        var targetDir = player.transform.position - transform.position;
        var forward = transform.forward;
        var localTarget = transform.InverseTransformPoint(player.transform.position);

        angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        
        if (isTurret)
        {
            
            Quaternion toRotation = Quaternion.LookRotation(targetDir, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotSpeed * Time.time);
        }
        else
        {
            var eulerAngleVelocity = new Vector3(0, angle, 0);
            var deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * rotSpeed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        
    }
}
