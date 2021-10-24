using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{

    public float capTime = 5f;
    public float capRadius = 10f;
    public int capStatus;
    public bool capped;
    public Renderer renderer;
    public Material currentMaterial;
    public Material[] materials;
    Collider[] colliders;

    public GameObject turret;
    public bool spawned = false;

    public AIManager aiManager;
    

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        //currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //janky workaround
        if (capped)
        {
            //currentMaterial = materials[1];
            //aiManager.pointsCapped++;
        }
        else
        {
            //currentMaterial = materials[2];
        }
        /*colliders = Physics.OverlapSphere(transform.position, capRadius);
        Gizmos.DrawWireSphere(transform.position, capRadius);

        if (colliders.Length > 0 && colliders != null)
        {

        }*/

       /* if (capStatus > 0)
        {
            currentMaterial = materials[1];
            //material.color = Color.blue;
            spawned = false;
        }
        else if (capStatus < 0)
        {
            currentMaterial = materials[2];
            //material.color = Color.red;
        }
        else if (capStatus < -1)
        {
            capStatus = -1;
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            capStatus++;
            capped = true; 
            renderer.material = materials[1];
            aiManager.pointsCapped++;
        }
        else if(other.tag == "Enemy")
        {
            capStatus--;
            capped = false;
            renderer.material = materials[2];
            //aiManager.pointsCapped--;
        }
        
        /*
        if (capStatus < 0 && spawned == false)
        {
            if (turret != null)
            {
                Instantiate(turret, transform.position, Quaternion.identity);
                spawned = true;
            }
        }*/

        
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
