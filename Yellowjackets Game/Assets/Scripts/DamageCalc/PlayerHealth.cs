using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 1000;
    public float maxhealth = 1000;
    public float armour = 0;
    public int lives = 3;

    public Inventory inventory;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        inventory = GetComponent<Inventory>();
        healthBar = GameObject.Find("PlayerHealth").GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
        if (health <= 0)
        {
            lives--;
            health = maxhealth;
            inventory.OnDeath(lives);
        }

    }

    public void OnDamage(float damage)
    {
        damage -= armour;
        health -= damage;
    }

    void Update()
    {
        healthBar.fillAmount = health / maxhealth;
    }
    
}
