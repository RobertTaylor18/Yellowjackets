using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public string weapon;
    public GameObject[] weapons;
    public GameObject weaponEquipped;

    public List<string> items = new List<string>()
        ;
    // Start is called before the first frame update
    void Start()
    {
        weapon = "default";
    }

    // Update is called once per frame
    public void dropWeapon()
    {
        foreach(GameObject WeaponDrop in weapons) {
        if(WeaponDrop.name == weapon)
            {
                Rigidbody rb = (Rigidbody)Instantiate(WeaponDrop.GetComponent<Rigidbody>(), transform.position, Quaternion.identity);
                rb.velocity = transform.up * 5;

                
                //WeaponDrop.GetComponent<Rigidbody>().velocity = transform.up*100;
            }
        }
    }
}
