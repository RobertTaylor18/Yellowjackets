using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    public float speed;
    public float boost;
    public ParticleSystem warp;
    public bool isInside;
    
    public float Ysensitivity;
    public float Xsensitivity;
    public float Rollsensitivity;
    public Text Ytext;
    public Text Xtext;
    public Text Rolltext;
    public float num = 0;
    public float num2 = 0;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Fly script added to: " + gameObject.name);
        Cursor.lockState = CursorLockMode.Locked;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "HiveShop")
        {
            isInside = true;
        }
        else 
        {
            isInside = false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var em = warp.emission;
        em.rateOverTime = num;


        if (Input.GetButton("Fire2") || isInside)
        {
            Hover();
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            if (Input.GetKey("w"))
            {
                transform.position += transform.forward * Time.deltaTime * boost;
                num = 80;
            }
            else
            {
                num = 0;
            }
            /*if (Input.GetKey("space"))
            {
                speed = 0;
                boost = 0;
            }
            else
            {
                speed = 20;
                boost = 40;
            }*/
            transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, 0);
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, -Input.GetAxis("Horizontal") * Rollsensitivity);
            }
        }
                sensitivity();
            
    



        

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
            terrainHeightWhereWeAre,
            transform.position.z);
        }
    }


    public void Hover()
    {
        speed = 7;

        transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, -Input.GetAxis("qe")*Rollsensitivity);

       
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += transform.right * Time.deltaTime * speed * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += transform.forward * Time.deltaTime * speed * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Altitude") != 0)
        {
            transform.position += transform.up * Time.deltaTime * speed * Input.GetAxis("Altitude");
        }
        
    }

    public void sensitivity()
    {
        Ytext.text = Ysensitivity.ToString();
        Xtext.text = Xsensitivity.ToString();
        Rolltext.text = Rollsensitivity.ToString();

        if (Input.GetKey("u"))
        {
            Ysensitivity += 0.5f; 
        }
        else if(Input.GetKey("j"))
        {
            Ysensitivity -= 0.5f;
        }
        
        if (Input.GetKey("i"))
        {
            Xsensitivity += 0.5f; 
        }
        else if(Input.GetKey("k"))
        {
            Xsensitivity -= 0.5f;
        }
        if (Input.GetKey("o"))
        {
            Rollsensitivity += 0.5f; 
        }
        else if(Input.GetKey("l"))
        {
            Rollsensitivity -= 0.5f;
        }

    }
}
