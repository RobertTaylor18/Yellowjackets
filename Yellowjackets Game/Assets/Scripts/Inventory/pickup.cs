using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string name;
    public string desc;
    public bool isWeapon;
    public Inventory inventory;
    public bool pickupAble = false;
    public bool bought = false;
    public float cost;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        StartCoroutine(WaitDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bought)
        {
            cost = 0;
        }

        if (other.gameObject.tag == "Player" && pickupAble)
        {
            if (isWeapon && bought)
            {
                inventory.dropWeapon();
                inventory.weapon = name;
            }
            else if (isWeapon && !bought && inventory.money >= cost)
            {
                inventory.money -= cost;
                inventory.dropWeapon();
                inventory.weapon = name;
            }
            else if (!isWeapon && inventory.money >= cost)
            {
                inventory.money -= cost;
                inventory.items.Add(name);
            }


            Destroy(this.gameObject);
        }
    }

    IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(2);
        pickupAble = true;
    }
}
