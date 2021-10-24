using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenAura : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.health += Time.deltaTime * (playerHealth.maxhealth/10);
        }
    }
}
