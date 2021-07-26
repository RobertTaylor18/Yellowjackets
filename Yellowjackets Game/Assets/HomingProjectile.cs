using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{

    public Transform target;
    public float force;
    public float rotationForce;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = FindClosestEnemy().transform;
    }

    void FixedUpdate()
    {
        Vector3 direction = target.position - rb.position;
        direction.Normalize();
        Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotationAmount * rotationForce;
        rb.velocity = transform.forward * force;
    }

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
