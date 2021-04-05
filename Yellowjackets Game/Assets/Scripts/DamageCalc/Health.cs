using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int maxhealth;

    public Inventory inventory;
    public float moneyValue;

    public GameObject FloatingTextPrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            inventory.money += moneyValue;
            Destroy(this.gameObject);
        }
    }

    public void OnDamage()
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = health.ToString();
        go.transform.LookAt(player.transform);
    }
}
