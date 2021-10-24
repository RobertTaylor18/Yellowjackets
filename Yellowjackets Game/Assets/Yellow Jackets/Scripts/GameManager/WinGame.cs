using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {
    public Health healthScript;

    void Start() {
        healthScript = GetComponent<Health>();
    }

    void Update() {
        if (healthScript.health <= 0) {
            SceneManager.LoadScene("Menu");
        }
    }
}
