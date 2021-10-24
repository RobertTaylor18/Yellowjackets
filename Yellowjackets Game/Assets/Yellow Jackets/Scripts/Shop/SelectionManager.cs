using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {
    //Defining assets used in highlighting interactables
    public Camera camera;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public Transform _selection;
    public string selectableTag = "Selectable";

    void Start() {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update() {
        //if the raycast is not hitting a selectable object then change the material to it's default
        if (_selection != null) {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.materials[1] = defaultMaterial;
            _selection = null;
        }

        //Creates a raycast using mouse position which is locked due to first person controller
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit)) {
            var selection = hit.transform;

            //If the raycast hits a selectable object change its material to the highlighted yellow
            if (selection.CompareTag(selectableTag)) {
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null) {
                    selectionRenderer.materials[1] = highlightMaterial;
                }
                _selection = selection;
            }
        }
    }
}
