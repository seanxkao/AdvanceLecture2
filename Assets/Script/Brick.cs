using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Ball") {
            GetComponent<Animator>().SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
