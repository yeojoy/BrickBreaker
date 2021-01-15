using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] bool isDebugMode = false;

    private Ball ball;

    // Start is called before the first frame update
    void Start() {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePosition = new Vector2(GetXPosition(), 0.25f);

        transform.position = paddlePosition;
    }

    private float GetXPosition() {

        float xPos = 0;
        if (isDebugMode) {
            xPos = ball.transform.position.x;
        } else {
            xPos = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        }
        
        return Mathf.Clamp(xPos, minX, maxX);
    }
}
