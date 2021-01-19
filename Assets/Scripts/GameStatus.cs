using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    [Range(0, 10)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestoryed = 10;
    [SerializeField] int currentScore = 0;
    [SerializeField] Text scoreText;

    private void Awake() {

        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        // Below codes are only for singleton pattern to keep user's score.
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update() {
        // 1f is regular time.
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentScore += pointsPerBlockDestoryed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScores() {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
}
