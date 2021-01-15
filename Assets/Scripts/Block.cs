﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakAudioClip;

    private Level level;
    private GameStatus gameStatus;

    private void Start() {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        level.BlockDestroyed();
        gameStatus.AddToScore();

        AudioSource.PlayClipAtPoint(breakAudioClip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
