using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBee : MonoBehaviour {
    public GameObject player;
    public PlayerHealth healthScript;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        healthScript = player.GetComponent<PlayerHealth>();
        healthScript.armour = 10;
    }
}
