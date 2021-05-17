using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public int enemyCount = 0;
    public Spawner[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount > 20)
        {
            foreach (Spawner spawner in spawners)
            {
                spawner.stopSpawning = true;
            }
        }
    }
}
