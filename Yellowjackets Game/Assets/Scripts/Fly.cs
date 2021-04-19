using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    public float speed;
    public float speedMod;
    public float speedCalc;
   
    public float boost;
    public ParticleSystem warp;
    public bool isInside;
    
    public float Ysensitivity;
    public float Xsensitivity;
    public float Rollsensitivity;
    
    public float warpStrength = 0;
    public Vector3 groundPoint;

    public bool tab;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        var em = warp.emission;
        em.rateOverTime = warpStrength;
        speedCalc = speed + speedMod;

        if (Input.GetKey("tab"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            tab = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            tab = false;
        }

        if (Input.GetButton("Fire2") || isInside)
        {
            Hover();
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * (speedCalc);
            if (Input.GetKey("w"))
            {
                transform.position += transform.forward * Time.deltaTime * ((speedCalc) * boost);
                warpStrength= 80;
            }
            else
            {
                warpStrength = 0;
            }


            if (!tab)
            {
                transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, 0);

                if (Input.GetAxis("qe") != 0)
                {
                    transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, -Input.GetAxis("qe") * Rollsensitivity);
                }
            }
        }
        
        sensitivity();

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
        speedCalc = (speed + speedMod)/1.3f;

        if (!tab)
        {
            transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, -Input.GetAxis("qe") * Rollsensitivity);
        }
        warpStrength = 0;

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += transform.right * Time.deltaTime * speedCalc * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += transform.forward * Time.deltaTime * speedCalc * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Altitude") != 0)
        {
            transform.position += transform.up * Time.deltaTime * speedCalc * Input.GetAxis("Altitude");
        }
        
    }

    public void sensitivity()
    {
        if (Input.GetKeyDown("u"))
        {
            Ysensitivity += 0.5f; 
        }
        else if(Input.GetKeyDown("j"))
        {
            Ysensitivity -= 0.5f;
        }
        
        if (Input.GetKeyDown("i"))
        {
            Xsensitivity += 0.5f; 
        }
        else if(Input.GetKeyDown("k"))
        {
            Xsensitivity -= 0.5f;
        }
        if (Input.GetKeyDown("o"))
        {
            Rollsensitivity += 0.5f; 
        }
        else if(Input.GetKeyDown("l"))
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
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            groundPoint = hit.point;
        }


    }
}
