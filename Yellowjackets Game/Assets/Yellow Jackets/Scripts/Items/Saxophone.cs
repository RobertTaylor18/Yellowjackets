using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saxophone : MonoBehaviour {
    public GameObject player;
    public ParticleSystem noteWarp;

    void Start() {
        player = GameObject.FindWithTag("Player");
        noteWarp = GameObject.Find("NoteWarp").GetComponent<ParticleSystem>();

        player.GetComponent<Fly>().boost = 2.5f;
        player.GetComponent<Fly>().warp = noteWarp;
        GameObject.Find("Warp").SetActive(false);
    }
}
