using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxCapacitor : MonoBehaviour
{
    public GameObject player;
    public Fly fly;
    public float speed;
    public float fluxDamageMod;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fly = player.GetComponent<Fly>();
        speed = fly.speedCalc;
    }

    // Update is called once per frame
    void Update()
    {
        if (fly.isBoosting)
        {
            fluxDamageMod = fly.speedCalc * fly.boost;
        }
        else 
        {
            fluxDamageMod = fly.speedCalc;
        }
    }
}
