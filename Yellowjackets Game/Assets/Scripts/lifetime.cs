using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    public float bulletTime = 10;
    public ParticleSystem particle; 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
        Destroy(this.gameObject, bulletTime);
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(bulletTime-1);

        Instantiate(particle, transform.position, Quaternion.identity);
    }

}
