using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxCapacitor : MonoBehaviour {
    public GameObject player;
    public Fly fly;
    public float speed;
    public float fluxDamageMod;

    void Start() {
        player = GameObject.FindWithTag("Player");
        fly = player.GetComponent<Fly>();
        speed = fly.speedCalc;
    }

    void Update() {
        if (fly.isBoosting) {
            fluxDamageMod = fly.speedCalc * fly.boost;
        } else {
            fluxDamageMod = fly.speedCalc;
        }
    }
}
