using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {
    public int enemyCount = 0;
    public Spawner[] spawners;

    public int pointsCapped = 0;
    public GameObject llamaBoss;

    void Update() {
        if (enemyCount > 20) {
            foreach (Spawner spawner in spawners) {
                spawner.stopSpawning = true;
            }
        }

        if (pointsCapped > 3) {
            llamaBoss.SetActive(true);
        }
    }
}
