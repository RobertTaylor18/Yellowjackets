using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool paused = false;

    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        /*if (GameObject.Find("Player") == null)
        {
            Instantiate(player, transform.position, transform.rotation);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") &&  paused == false)
        {
            Time.timeScale = 0;
            paused = true;
            pauseUI.SetActive(true);
            inGameUI.SetActive(false);
        }
        else if (Input.GetKeyDown("escape") && paused)
        {
            Time.timeScale = 1;
            paused = false;
            pauseUI.SetActive(false);
            inGameUI.SetActive(true);
        }

        if (Input.GetKeyDown("p"))
            Application.LoadLevel(Application.loadedLevel);
}
}
