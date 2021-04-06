using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health;
    public float maxhealth;

    public Inventory inventory;
    public float moneyValue;

    public GameObject FloatingTextPrefab;
    public GameObject player;

    public GameObject healthBarCanvas;
    public GameObject healthBarUI;
    public GameObject healthBarObj;
    public float uiAlpha = 0;
    public bool isFading = false;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        spawnHealthBar();
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            inventory.money += moneyValue;
            Destroy(this.gameObject);   
        }
        healthBarUI.transform.LookAt(player.transform);
        healthBarUI.transform.rotation = Quaternion.LookRotation(player.transform.forward);
        
        
    }

    void Update()
    {
        
            
        
        healthBarUI.GetComponent<CanvasGroup>().alpha = uiAlpha;
        healthBar.fillAmount = health / maxhealth;

        if (isFading && uiAlpha >= 0)
        {
                uiAlpha -= Time.deltaTime;
        }
        else
        {
            isFading = false;
        }
        
    }

    public void OnDamage()
    {
        uiAlpha = 1;
        StartCoroutine(timer());
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = health.ToString();
        go.transform.LookAt(player.transform);
        go.transform.rotation = Quaternion.LookRotation(player.transform.forward);

        
    }

    public void spawnHealthBar()
    {
        var go = Instantiate(healthBarCanvas, transform.position, Quaternion.identity, transform);
        healthBarUI = go.GetComponentInChildren<CanvasGroup>().gameObject;
        // healthBarObj = healthBarUI.GetComponentInChildren<Image>().gameObject;


        healthBarObj = healthBarUI.transform.GetChild(1).gameObject;
        healthBar = healthBarObj.GetComponent<Image>();
        
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(3f);

        isFading = true;
    }
}
