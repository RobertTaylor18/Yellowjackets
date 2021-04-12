using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{

    public float capTime=5f;
    public float capRadius=10f;
    public int capStatus;
    public Material material;
    Collider[] colliders;

    public GameObject turret;
    public bool spawned = false;
    

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        /*colliders = Physics.OverlapSphere(transform.position, capRadius);
        Gizmos.DrawWireSphere(transform.position, capRadius);

        if (colliders.Length > 0 && colliders != null)
        {

        }*/

        if (capStatus > 0)
        {
            material.color = Color.blue;
            spawned = false;
        }
        else if (capStatus < 0)
        {
            material.color = Color.red;
        }
        else if (capStatus < -1)
        {
            capStatus = -1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            capStatus++; 
        }
        else if(other.tag == "Enemy")
        {
            capStatus--;
        }
        
        if (capStatus < 0 && spawned == false)
        {
            Instantiate(turret, transform.position, Quaternion.identity);
            spawned = true;
        }

        
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            capStatus--;
        }
        else if (other.tag == "Enemy")
        {
            capStatus++;
        }
    }
}
