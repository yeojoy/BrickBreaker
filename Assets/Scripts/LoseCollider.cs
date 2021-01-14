using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private SceneLoadManager sceneLoadManager;

    // Start is called before the first frame update
    void Start() {
        sceneLoadManager = FindObjectOfType<SceneLoadManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.name + " is collided");
        sceneLoadManager.MoveGameOverScene();
    }
}
