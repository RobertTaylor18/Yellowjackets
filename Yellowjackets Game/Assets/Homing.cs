using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    //public float missileVelocity = 300;
    //public float turn = 20;
    //public RigidBody homingMissile;
    //public GameObject missile;
    public GameObject targetObj;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //homingMissile = transform.rigidbody;
        //Fire();

        targetObj = FindClosestEnemy();
        
    }

    void FixedUpdate()
    {
        
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 50, ForceMode.Force);
    }

    void Update()
    {
        transform.LookAt(targetObj.transform);
    }

    /*public void Fire()
    {
        yield WaitForSeconds(2);

        float distance = Mathf.Infinity;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            //Vector3 diff = (go.transform.position = transform.position).sqrMagnitude;
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) 
            {
                distance = diff;
                target = go.transform;
            }
        }
    }*/

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

}
