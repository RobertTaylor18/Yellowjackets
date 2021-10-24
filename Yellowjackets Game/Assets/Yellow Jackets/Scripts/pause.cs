using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool paused = false;

    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject player;
    public AudioListener audioListener;

    public Text Ytext;
    public Text Xtext;
    public Text Rolltext;

    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioListener = player.GetComponentInChildren<AudioListener>();
        /*if (GameObject.Find("Player") == null)
        {
            Instantiate(player, transform.position, transform.rotation);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p") &&  paused == false)
        {
            player = GameObject.FindWithTag("Player");
            player.GetComponent<Fly>().tab = true;
            paused = true;
            pauseUI.SetActive(true);
            sensitivity();
            inGameUI.SetActive(false);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("p") && paused)
        {
            player.GetComponent<Fly>().tab = false;
            Time.timeScale = 1;
            paused = false;
            pauseUI.SetActive(false);
            inGameUI.SetActive(true);
        }

        if (Input.GetKeyDown("y"))
            Application.LoadLevel(Application.loadedLevel);
    }

    void sensitivity()
    {
        Ytext = GameObject.Find("Ysens").GetComponent<Text>();
        Xtext = GameObject.Find("Xsens").GetComponent<Text>();
        Rolltext = GameObject.Find("Rollsens").GetComponent<Text>();
        Ytext.text = player.GetComponent<Fly>().Ysensitivity.ToString();
        Xtext.text = player.GetComponent<Fly>().Xsensitivity.ToString();
        Rolltext.text = player.GetComponent<Fly>().Rollsensitivity.ToString();
    }

    public void quitToMenu()
    {
        Destroy(player);
        SceneManager.LoadScene("Menu");
        Destroy(this.gameObject);
    }

    public void volume(float value)
    {
        AudioListener.volume = value;
    }
}
