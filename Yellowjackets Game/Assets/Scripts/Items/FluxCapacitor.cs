using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxCapacitor : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    public float speed;
    public float fluxDamageMod;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        speed = playerController.speedCalc;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isBoosting)
        {
            fluxDamageMod = playerController.speedCalc * playerController.boost;
        }
        else 
        {
            fluxDamageMod = playerController.speedCalc;
        }
    }
}
