using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour {

    // Controls
    public float Ysensitivity;
    public float Xsensitivity;
    public float Rollsensitivity;
    public bool isCursorFree;

    // Movement and navigation
    public float speedBase;
    public float speedModifier;
    public float speedCalc;

    public bool isInside;
    public bool isBoosting;
    public float boost;

    // Particles
    public ParticleSystem warp;
    public ParticleSystem warpOriginal;
    public float warpStrength = 0;

    // Other
    public Vector3 groundPoint;
    public GameObject playerCanvas;
    public Animator anim;

    // Initialization
    void Start() {
        Debug.Log("PlayerController compoment added to: " + gameObject.name);

        DontDestroyOnLoad(gameObject);

        playerCanvas = GameObject.Find("PlayerCanvas(Clone)");
        anim.SetInteger("playerState", 0);

        Cursor.lockState = CursorLockMode.Locked;
        isInside = SceneManager.GetActiveScene().name == "HiveShop";
    }

    // Update
    void Update() {
        // Controls
        UpdateCursorControls();
        UpdateSensitivityControls();

        // Movement and navigation
        if (Input.GetButton("Fire2") || isInside) {
            UpdateMovementHover();
        } else {
            UpdateMovementRegular();
        }
        UpdateGroundCheck();

        // Effects
        UpdateParticles();
    }

    private void UpdateCursorControls() {
        isCursorFree = Input.GetKey("tab") || playerCanvas.GetComponent<pause>().paused;
        Cursor.lockState = isCursorFree ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    public void UpdateSensitivityControls() {
        if (Input.GetKeyDown("u")) {
            Ysensitivity += 0.5f;
        } else if (Input.GetKeyDown("j")) {
            Ysensitivity -= 0.5f;
        }

        if (Input.GetKeyDown("i")) {
            Xsensitivity += 0.5f;
        } else if (Input.GetKeyDown("k")) {
            Xsensitivity -= 0.5f;
        }

        if (Input.GetKeyDown("o")) {
            Rollsensitivity += 0.5f;
        } else if (Input.GetKeyDown("l")) {
            Rollsensitivity -= 0.5f;
        }
    }

    private void UpdateMovementRegular() {
        CalculateSpeed(.6f);
        transform.position += transform.forward * Time.deltaTime * speedCalc;

        // Boosting
        isBoosting = Input.GetKey("w");
        if (isBoosting) {
            warpStrength = 80;
            anim.SetInteger("playerState", 2);
            transform.position += transform.forward * Time.deltaTime * speedCalc * boost;
        } else {
            warpStrength = 0;
            anim.SetInteger("playerState", 0);
        }

        // Rolling
        if (!isCursorFree) {
            transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, 0);
            if (Input.GetAxis("qe") != 0) {
                transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, -Input.GetAxis("qe") * Rollsensitivity);
            }
        }
    }

    private void UpdateMovementHover() {
        CalculateSpeed(1.3f);
        anim.SetInteger("playerState", 1);
        warpStrength = 0;

        if (!isCursorFree) {
            transform.Rotate(-Input.GetAxis("Mouse Y") * Ysensitivity, Input.GetAxis("Mouse X") * Xsensitivity, -Input.GetAxis("qe") * Rollsensitivity);
        }

        if (Input.GetAxis("Horizontal") != 0) {
            transform.position += transform.right * Time.deltaTime * speedCalc * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") != 0) {
            transform.position += transform.forward * Time.deltaTime * speedCalc * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Altitude") != 0) {
            transform.position += transform.up * Time.deltaTime * speedCalc * Input.GetAxis("Altitude");
        }
    }

    private void UpdateGroundCheck() {
        RaycastHit hit;
        bool hitMade = Physics.Raycast(
            transform.position,
            Vector3.down,
            out hit,
            Mathf.Infinity,
            LayerMask.GetMask("floor")
        );
        
        if (hitMade) {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            groundPoint = hit.point;
        }

        /*
        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y) {
            transform.position = new Vector3(
                transform.position.x,
                terrainHeightWhereWeAre,
                transform.position.z
            );
        }
        */
    }

    private void UpdateParticles() {
        ParticleSystem.EmissionModule em = warp.emission;
        em.rateOverTime = warpStrength;
    }

    // Utility methods
    private void CalculateSpeed(float dampener = 1f) {
        speedCalc = (speedBase + speedModifier) / dampener;
    }
}
