using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneUpManager : MonoBehaviour {
    public GameObject player;
    public PlayerHealth health;
    public Inventory inventory;
    public GameObject beeSprite;
    public float cost = 200;

    public Text[] textBoxes;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        inventory = player.GetComponent<Inventory>();
        SpawnOneUps();
    }

    public void SpawnOneUps() {

        for (int i = 0; i < health.lives; i++) {
            GameObject bee = Instantiate(beeSprite, transform.position, transform.rotation, this.gameObject.transform);
            bee.transform.localPosition += new Vector3(i * 2, 0, 0);
        }

        textBoxes[0].text = "Current Lives: <b>" + health.lives.ToString() + "</b>";
        textBoxes[1].text = "Cost: <b>" + cost.ToString() + "</b>";

    }

    public void AddOneUp() {
        if (inventory.money >= cost) {
            inventory.money -= cost;
            health.lives++;
            cost = Mathf.Round(cost * 2);
        }
    }
}