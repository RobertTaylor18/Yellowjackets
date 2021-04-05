using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int maxhealth;

    public Inventory inventory;
    public float moneyValue;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;

        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            inventory.money += moneyValue;
            Destroy(this.gameObject);
        }
    }
}
