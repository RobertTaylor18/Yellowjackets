using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int maxhealth;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    void FixedUpdate()
    {
        if (health<= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
