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
        }
        else if (capStatus < 0)
        {
            material.color = Color.red;
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
