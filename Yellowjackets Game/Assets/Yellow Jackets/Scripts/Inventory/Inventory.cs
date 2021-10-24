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
    public GameObject swordObj;
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
            var em = GameObject.Find("NoteWarp").GetComponent<ParticleSystem>().emission;
            em.rateOverTime = 0;
        }

        //expensive move to when it is added or removed from list
        if (items.Contains("wasabee"))
        {
            itemEquips[1].SetActive(true);
        }
        else
        {
            itemEquips[1].SetActive(false);
        }

        if (items.Contains("bumblegum"))
        {
            itemEquips[2].SetActive(true);
        }
        else
        {
            itemEquips[2].SetActive(false);
        }

        if (items.Contains("fluxcapacitor"))
        {
            itemEquips[3].SetActive(true);
        }
        else
        {
            itemEquips[3].SetActive(false);
        }
        
        if (items.Contains("beeserker"))
        {
            itemEquips[4].SetActive(true);
        }
        else
        {
            itemEquips[4].SetActive(false);
        }
        
        if (items.Contains("metal bee"))
        {
            itemEquips[5].SetActive(true);
        }
        else
        {
            itemEquips[5].SetActive(false);
        }

        if (Input.GetKey("l"))
        {
            weapon = "sword";
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
        if (name == "sword")
        {
            swordObj.SetActive(true);
        }
    }


    public void OnDeath(int lives)
    {
        //Clearing player state on death and prepping for teleport to hive
        //Some edge cases created by items are also accounted for
        money = 0;
        weapon = "default";
        GetComponent<PlayerHealth>().armour = 0;
        swordObj.SetActive(false);
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
