using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBehind : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject rearCamera;

    void Update() {
        bool rearView = Input.GetKey("f");
        mainCamera.SetActive(!rearView);
        rearCamera.SetActive(rearView);
    }
}
