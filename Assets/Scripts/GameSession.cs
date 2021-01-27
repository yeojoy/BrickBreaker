using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    [Range(0, 10)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake() {

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        // Below codes are only for singleton pattern to keep user's score.
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start() {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update() {
        // 1f is regular time.
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int pointsOfBlock) {
        currentScore += pointsOfBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScores() {
        Destroy(gameObject);
    }
}
