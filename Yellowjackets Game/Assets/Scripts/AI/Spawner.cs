using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public AIManager aiManager;

    // Start is called before the first frame update
    void Start()
    {
        startSpawning();
        aiManager = GameObject.Find("AIManager").GetComponent<AIManager>();
    }

    public void startSpawning()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        aiManager.enemyCount++;
        Instantiate(Enemy, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

}
