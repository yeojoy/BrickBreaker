using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // This field is for debugging.
    [SerializeField] int breakableBlocks;
    private SceneLoadManager sceneLoadManager;

    private void Start() {
        sceneLoadManager = FindObjectOfType<SceneLoadManager>();
    }

    public void CountBlocks() {
        breakableBlocks++;
    }

    public void BlockDestroyed() {
        breakableBlocks--;

        if (breakableBlocks <= 0) {
            sceneLoadManager.MoveNextScene();
        }
    }
}
