using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saxophone : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem noteWarp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        noteWarp = GameObject.Find("NoteWarp").GetComponent<ParticleSystem>();

        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.boost = 2.5f;
        playerController.warp = noteWarp;
        GameObject.Find("Warp").SetActive(false);
    }

}
