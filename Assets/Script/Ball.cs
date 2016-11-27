using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 speed;
    int score;
    bool alive;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(4, 4);
        die();
	}

    public void spawn(Vector3 pos) {
        alive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = pos;
        rb.velocity = speed;
    }
    public void die()
    {
        alive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        rb.velocity = Vector2.zero;
    }

    public bool isAlive() {
        return alive;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            score++;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x);
        float a = Mathf.Repeat(angle+360f, 90f);
        float b = Mathf.Clamp(a, 20, 70);
        angle = Mathf.Deg2Rad*(angle - a + b);
        float s = rb.velocity.magnitude;
        rb.velocity = s * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public int getScore() {
        return score;
    }
}
