using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public float money;
    public Text moneyText;
    public string weapon;
    public GameObject[] weapons;
    public GameObject[] itemEquips;
    public List<string> items = new List<string>();

    public Fly fly;
    public GameObject playerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        moneyText = GameObject.Find("Lbl_Money").GetComponent<Text>();
        weapon = "default";
        fly = GetComponent<Fly>();
        playerCanvas = GameObject.Find("PlayerCanvas(Clone)");
    }

    void Update()
    {
       moneyText.text = money.ToString();

        if (Input.GetKeyDown("t"))
        {
            money += 100f;
        }if (Input.GetKeyDown("g"))
        {
            money -= 100f;
        }
    }

    void FixedUpdate()
    {
        if(money < 0)
        {
            money = 0;
        }

        if (items.Contains("saxophone"))
        {
            itemEquips[0].SetActive(true);
        }
        else
        {
            itemEquips[0].SetActive(false);
            
        }


        if (items.Contains("wasabee"))
        {
            itemEquips[1].SetActive(true);
        }
        else
        {
            itemEquips[1].SetActive(false);
        }
    }

    // Update is called once per frame
    public void dropWeapon()
    {
        foreach(GameObject WeaponDrop in weapons) {
        if(WeaponDrop.name == weapon)
            {
                Rigidbody rb = (Rigidbody)Instantiate(WeaponDrop.GetComponent<Rigidbody>(), transform.position, Quaternion.identity);
                rb.useGravity = true;
                rb.velocity = transform.up * 5;
                WeaponDrop.GetComponent<Pickup>().bought = true;

                
                //WeaponDrop.GetComponent<Rigidbody>().velocity = transform.up*100;
            }
        }
    }

    public void Equip(string name)
    {
        
    }


    public void OnDeath(int lives)
    {
        money = 0;
        weapon = "default";
        items.Clear();
        fly.isInside = true;
        fly.warpOriginal.gameObject.SetActive(true);
        fly.warp = fly.warpOriginal;
        
        fly.warpStrength = 0;
        if (lives > 0)
        {
            SceneManager.LoadScene("HiveShop");
        }
        else
        {
            Destroy(playerCanvas);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);
        }
    }
}
