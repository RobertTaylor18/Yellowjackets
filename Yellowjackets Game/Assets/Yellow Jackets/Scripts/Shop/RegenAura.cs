using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenAura : MonoBehaviour {
    public GameObject player;
    public PlayerHealth playerHealth;

    void Start() {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject == player) {
            playerHealth.health += Time.deltaTime * (playerHealth.maxhealth / 10);
        }
    }
}
