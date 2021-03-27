using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool paused = false;

    public GameObject inGameUI;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") &&  paused == false)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else if (Input.GetKeyDown("escape") && paused)
        {
            Time.timeScale = 1;
            paused = false;
        }

        if (Input.GetKeyDown("p"))
            Application.LoadLevel(Application.loadedLevel);
}
}