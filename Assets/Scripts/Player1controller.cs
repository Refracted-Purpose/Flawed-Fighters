using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1controller : MonoBehaviour
{
    private bool isGrounded;
    private Rigidbody2D rb;
    //Public variables set in Unity Inspector
    public float xSpeed;
    public float jumpStrength;
    //initialize private variables in start
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame, Fixed used for physics
    void FixedUpdate()
    {
        float xHat = new Vector2(Input.GetAxis("Horizontal"), 0).normalized.x;
        float vx = xHat * xSpeed;
        if (isGrounded) {
            rb.AddForce(transform.right * vx);
        } else {
            rb.AddForce(transform.right * 0.5f * vx);
        }

        float yHat = new Vector2(0, Input.GetAxis("Vertical")).normalized.y;
        if (isGrounded && yHat == 1) {
            float vy = yHat * jumpStrength;
            isGrounded = false;
            rb.AddForce(transform.up * vy);
        }
        if (transform.position.y < -5) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Get rid of this when no longer necessary
        Debug.Log(collision.gameObject.tag);
        isGrounded = collision.gameObject.tag == "Ground";
    }
}
