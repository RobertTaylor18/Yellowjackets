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
        shooting.AttackDamageMod += mod;
        stats[0].text = shooting.AttackDamageMod.ToString();
    }
    
    public void AttackSpeed(float mod)
    {
        shooting.AttackSpeedMod += mod;
        stats[1].text = shooting.AttackSpeedMod.ToString();
    }
    
    public void MoveSpeed(float mod)
    {
        fly.speedMod += mod;
        stats[2].text = fly.speedMod.ToString();
    }

    public void ProjectileSize(float mod)
    {
        shooting.projectileSize += mod;
        stats[3].text = shooting.projectileSize.ToString();
    }
}
