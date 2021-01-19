using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {

    public void MoveNextScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void MoveFirstScene() {
        SceneManager.LoadScene(0);
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.ResetScores();
    }

    public void MoveGameOverScene() {
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
