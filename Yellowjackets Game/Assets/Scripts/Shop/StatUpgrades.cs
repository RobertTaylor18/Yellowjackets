using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUpgrades : MonoBehaviour
{
    public GameObject player;
    public Shooting shooting;
    public Fly fly;
    public Text[] stats;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shooting = player.GetComponent<Shooting>();
        fly = player.GetComponent<Fly>();
        stats[0].text = shooting.AttackDamageMod.ToString();
        stats[1].text = shooting.AttackSpeedMod.ToString();
        stats[2].text = fly.speedMod.ToString();
        stats[3].text = shooting.projectileSize.ToString();
    }


    public void AttackDamage(float mod)
    {
        if (mod > 0 && shooting.AttackDamageMod < 3 || mod < 0 && shooting.AttackDamageMod > 1)
        {
            shooting.AttackDamageMod += mod;
            stats[0].text = shooting.AttackDamageMod.ToString();
        }
    }
    
    public void AttackSpeed(float mod)
    {
        if (mod > 0 && shooting.AttackSpeedMod < 400 || mod < 0 && shooting.AttackDamageMod > 0)
        {
            shooting.AttackSpeedMod += mod;
            stats[1].text = shooting.AttackSpeedMod.ToString();
        }
    }
    
    public void MoveSpeed(float mod)
    {
        if (mod > 0 && fly.speedMod < 10 || mod < 0 && fly.speedMod > 0)
        {
            fly.speedMod += mod;
            stats[2].text = fly.speedMod.ToString();
        }
    }

    public void ProjectileSize(float mod)
    {
        if (mod > 0 && shooting.projectileSize < 0.6f || mod < 0 && shooting.projectileSize > 0.2f)
        {
            shooting.projectileSize += mod;
            stats[3].text = shooting.projectileSize.ToString();
        }
    }
}
