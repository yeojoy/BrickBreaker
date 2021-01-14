using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

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

        //float xPos = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        float xPos = ball.transform.position.x;

        return Mathf.Clamp(xPos, minX, maxX);
    }
}
