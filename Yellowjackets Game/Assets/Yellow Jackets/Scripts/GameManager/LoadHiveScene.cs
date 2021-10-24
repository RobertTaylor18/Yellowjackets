using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHiveScene : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Fly>().isInside = true;
            other.gameObject.GetComponent<Fly>().warpStrength = 0;
            SceneManager.LoadScene("HiveShop");
            //SceneManager.LoadScene("HiveShop", LoadSceneMode.Additive);
            //SceneManager.MoveGameObjectToScene(FPSControllerr.gameObject, sceneToLoad);
        }
    }
}
