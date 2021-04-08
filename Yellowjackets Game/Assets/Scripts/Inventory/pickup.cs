using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public string name;
    public string desc;
    public bool isWeapon;
    public Inventory inventory;
    public bool pickupAble = false;
    public float cost;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        StartCoroutine(WaitDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && pickupAble && inventory.money > cost)
        {
            if (isWeapon)
            {
                inventory.money -= cost;
                inventory.dropWeapon();
                inventory.weapon = name;
            }
            else
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
