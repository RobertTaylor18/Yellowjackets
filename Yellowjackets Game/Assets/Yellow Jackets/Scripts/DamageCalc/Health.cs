using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
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
    public bool isFading = true;
    private IEnumerator coroutine;
    public Image healthBar;

    void Start() {
        health = maxhealth;
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        spawnHealthBar();
        coroutine = timer();
    }

    void FixedUpdate() {
        if (health <= 0) {
            inventory.money += moneyValue;
            Destroy(this.gameObject);
        }
        healthBarUI.transform.LookAt(player.transform);
        healthBarUI.transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }

    void Update() {
        healthBarUI.GetComponent<CanvasGroup>().alpha = uiAlpha;
        healthBar.fillAmount = health / maxhealth;
        if (isFading && uiAlpha > 0) {
            uiAlpha -= Time.deltaTime;

        } else if (uiAlpha <= 0) {
            isFading = false;
        }
    }

    public void OnDamage(float damage) {
        health -= damage;
        isFading = false;
        uiAlpha = 1;

        /*if (isFading)
        {
            isFading = false;
           // StopCoroutine(coroutine);
        }*/
        //isFading = true;
        StopCoroutine(timer());
        StartCoroutine(timer());
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damage.ToString();
        go.transform.LookAt(player.transform);
        go.transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }

    public void spawnHealthBar() {
        var go = Instantiate(healthBarCanvas, transform.position, Quaternion.identity, transform);
        healthBarUI = go.GetComponentInChildren<CanvasGroup>().gameObject;
        // healthBarObj = healthBarUI.GetComponentInChildren<Image>().gameObject;

        healthBarObj = healthBarUI.transform.GetChild(1).gameObject;
        healthBar = healthBarObj.GetComponent<Image>();
    }

    public IEnumerator timer() {
        isFading = false;
        uiAlpha = 1;
        yield return new WaitForSeconds(2f);
        isFading = true;

        /*while (uiAlpha > 0)
        {
            uiAlpha -= .1f;
            yield return new WaitForSeconds(1f);
        }*/
    }
}
