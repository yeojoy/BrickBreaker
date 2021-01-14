using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakAudioClip;

    private Level level;

    private void Start() {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        level.ReduceBlockCounts();
        AudioSource.PlayClipAtPoint(breakAudioClip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
