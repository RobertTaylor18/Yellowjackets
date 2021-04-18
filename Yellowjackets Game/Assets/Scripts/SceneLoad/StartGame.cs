using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public GameObject pause;

    public void LoadScene() 
    {
        
        Instantiate(pause, transform.position, transform.rotation);
        StartCoroutine(Spawn());
        
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        Instantiate(player, transform.position, transform.rotation);
        SceneManager.LoadScene("WeaponTest");
    }
}
