using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string sceneName;
    public GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
        player.transform.position = Vector3.zero;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Fly>().isInside = false;
            other.gameObject.GetComponent<Fly>().warpStrength = 0;
            LoadScene();
        }
    }

    public void LoadScene() {
        SceneManager.LoadScene(sceneName);
    }
}
