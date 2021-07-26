using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUpgrades : MonoBehaviour
{
    public GameObject player;
    public Shooting shooting;
    public PlayerController playerController;
    public PlayerHealth playerHealth;
    public Inventory inventory;
    public Text[] stats;
    public Text[] costs;
    public float cost = 200;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shooting = player.GetComponent<Shooting>();
        playerController = player.GetComponent<PlayerController>();
        playerHealth = player.GetComponent<PlayerHealth>();
        inventory = player.GetComponent<Inventory>();
        stats[0].text = shooting.AttackDamageMod.ToString();
        stats[1].text = shooting.AttackSpeedModifier.ToString();
        stats[2].text = playerController.speedModifier.ToString();
        stats[3].text = shooting.projectileSize.ToString();
        stats[4].text = playerHealth.maxhealth.ToString();
        //costs[0].text = cost.ToString();
        //costs[1].text = cost.ToString();

    }


    public void AttackDamage(float mod)
    {
            if (mod > 0 && shooting.AttackDamageMod < 3 && inventory.money >= cost) {
                shooting.AttackDamageMod += mod;
                stats[0].text = shooting.AttackDamageMod.ToString();
                inventory.money -= cost;
                //cost += 100; 
            }
            else if (mod < 0 && shooting.AttackDamageMod > 1)
            {
                shooting.AttackDamageMod += mod;
                stats[0].text = shooting.AttackDamageMod.ToString();
                inventory.money += cost;
        }
    }
    
    public void AttackSpeed(float mod)
    {
        if (mod > 0 && shooting.AttackSpeedModifier < 400 && inventory.money >= cost)
        {
            shooting.AttackSpeedModifier += mod;
            stats[1].text = shooting.AttackSpeedModifier.ToString();
            inventory.money -= cost;
        }
        else if (mod < 0 && shooting.AttackSpeedModifier > 0)
        {
            shooting.AttackSpeedModifier += mod;
            stats[1].text = shooting.AttackSpeedModifier.ToString();
            inventory.money += cost;
        }
    }
    
    public void MoveSpeed(float mod)
    {
        if (mod > 0 && playerController.speedModifier < 10  && inventory.money >= cost)
        {
            playerController.speedModifier += mod;
            stats[2].text = playerController.speedModifier.ToString();
            inventory.money -= cost;
        }
        else if (mod < 0 && playerController.speedModifier > 0)
        {
            playerController.speedModifier += mod;
            stats[2].text = playerController.speedModifier.ToString();
            inventory.money += cost;
        }
    }

    public void ProjectileSize(float mod)
    {
        if (mod > 0 && shooting.projectileSize < 0.6f  && inventory.money >= cost)
        {
            shooting.projectileSize += mod;
            stats[3].text = shooting.projectileSize.ToString();
            inventory.money -= cost;
        }
        else if (mod < 0 && shooting.projectileSize > 0.2f)
        {
            shooting.projectileSize += mod;
            stats[3].text = shooting.projectileSize.ToString();
            inventory.money += cost;
        }
    }
    
    public void MaxHealth(float mod)
    {
        if (mod > 0 && playerHealth.maxhealth < 500 && inventory.money >= cost)
        {
            playerHealth.maxhealth += mod;
            playerHealth.health = playerHealth.maxhealth;
            stats[4].text = playerHealth.maxhealth.ToString();
            inventory.money -= cost;
        }
        else if (mod < 0 && playerHealth.maxhealth > 100)
        {
            playerHealth.maxhealth += mod;
            playerHealth.health = playerHealth.maxhealth;
            stats[4].text = playerHealth.maxhealth.ToString();
            inventory.money += cost;
        }
    }
}
