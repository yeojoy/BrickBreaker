﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    [Range(0, 10)] [SerializeField] float gameSpeed = 1f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // 1f is regular time.
        Time.timeScale = gameSpeed;
    }
}
