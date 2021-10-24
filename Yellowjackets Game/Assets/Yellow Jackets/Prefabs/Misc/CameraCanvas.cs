using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvas : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        GetComponent<Canvas>().worldCamera = camera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
