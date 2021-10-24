using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookBehind : MonoBehaviour
{

    public GameObject camera;
    public GameObject camera2;
    //public GameObject camera3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            camera.SetActive(false);
            camera2.SetActive(true);
            //camera3.SetActive(false);
        }
        else if (Input.GetKey("b"))
        {
            camera.SetActive(false);
            camera2.SetActive(false);
            //camera3.SetActive(true);
        }
        else
        {
            camera.SetActive(true);
            camera2.SetActive(false);
            //camera3.SetActive(false);
        }
    }
}
