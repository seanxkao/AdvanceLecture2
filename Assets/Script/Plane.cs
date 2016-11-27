using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {
    float speed;
    float max;
    float min;
    Ball ball;

	void Start () {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        speed = 7f;
        max = 7f;
        min = -7f;
	}
	
	void Update () {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
            pos.x += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            pos.x -= speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min, max);
        transform.position = pos;
        if (Input.GetKeyDown(KeyCode.Space) && !ball.isAlive())
            ball.spawn(transform.position + new Vector3(0, 1, 0));
	}
}
