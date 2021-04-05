using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ShopManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject[] weapons;
    public GameObject[] items;
    public GameObject[] allShopItems;
    public Transform[] positions;
    public Text[] textBoxes;
    public Text[] priceBoxes;

    // Start is called before the first frame update
    void Start()
    {
        
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        weapons = inventory.weapons;
        allShopItems = weapons.Concat(items).ToArray();
        RefreshShop();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            RefreshShop();
        }
    }

    void RefreshShop()
    {
        int i = 0;
        foreach (Transform position in positions)
        {
            
            GameObject existingItem = position.GetChild(0).gameObject;
            Destroy(existingItem);

            GameObject MyItem = allShopItems[Random.Range(0, allShopItems.Length)];
            Instantiate(MyItem, position);
            MyItem.transform.position = Vector3.zero;
            textBoxes[i].text = MyItem.transform.name;
            priceBoxes[i].text = MyItem.GetComponent<pickup>().cost.ToString();
            i++;
        }
    }
}
