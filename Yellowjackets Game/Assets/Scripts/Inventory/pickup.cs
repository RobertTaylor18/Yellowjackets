using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public string name;
    public bool isWeapon;
    public Inventory inventory;
    public bool pickupAble = false;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        StartCoroutine(WaitDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && pickupAble)
        {
            if (isWeapon)
            {
                inventory.dropWeapon();
                inventory.weapon = name;
            }
            else
            {
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
