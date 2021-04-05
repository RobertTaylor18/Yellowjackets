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
    public float warpStrength = 0;
    public Vector3 groundPoint;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Fly script added to: " + gameObject.name);
        Cursor.lockState = CursorLockMode.Locked;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
        Ytext = GameObject.Find("Ysens").GetComponent<Text>();
        Xtext = GameObject.Find("Xsens").GetComponent<Text>();
        Rolltext = GameObject.Find("Rollsens").GetComponent<Text>();

        if (sceneName == "HiveShop")
        {
            isInside = true;
        }
        else 
        {
            isInside = false;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        var em = warp.emission;
        em.rateOverTime = warpStrength;


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
                warpStrength= 80;
            }
            else
            {
                warpStrength = 0;
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
        
        //sensitivity();

        GroundCheck();
            
    



        

        /*float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
            terrainHeightWhereWeAre,
            transform.position.z);
        }*/
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

    public void GroundCheck()
    {
        RaycastHit hit;
        int layerMask = 1 << 9;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            groundPoint = hit.point;
        }


    }
}
