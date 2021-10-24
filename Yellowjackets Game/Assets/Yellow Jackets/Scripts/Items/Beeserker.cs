using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beeserker : MonoBehaviour {
    public GameObject player;
    public PlayerHealth healthScript;

    public float missingHealth;
    public float beeserkerMod;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        healthScript = player.GetComponent<PlayerHealth>();
        missingHealth = healthScript.maxhealth - healthScript.health;
    }

    void Update() {
        missingHealth = healthScript.maxhealth - healthScript.health;
        beeserkerMod = missingHealth / 2;

        if (beeserkerMod < 0) {
            beeserkerMod = 0;
        }
    }
}
