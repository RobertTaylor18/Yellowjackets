using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvas : MonoBehaviour {
    public Camera camera;

    void Start() {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        GetComponent<Canvas>().worldCamera = camera;
    }
}
