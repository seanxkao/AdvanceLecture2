using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {
    Ball ball;

	void Start () {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject == ball.gameObject) {
            if(ball.isAlive())
                ball.die();
        }
    }
}
