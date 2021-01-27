using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakAudioClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 1;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int pointOfThisBlock = 10;

    // only used for debugging.
    [SerializeField] int timesHit;

    private Level level;
    private GameSession gameStatus;
    private const String BREAKABLE_TAG = "Breakable";

    private void Start() {
        CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == BREAKABLE_TAG) {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == BREAKABLE_TAG) {
            HandleHit();
        }
    }

    private void HandleHit() {
        timesHit++;
        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Block Sprite is missing from array." + gameObject.name);
        }

    }

    private void DestroyBlock() {
        PlayBlockDestroySFX();
        level.BlockDestroyed();

        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX() {
        gameStatus.AddToScore(pointOfThisBlock);
        AudioSource.PlayClipAtPoint(breakAudioClip, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
