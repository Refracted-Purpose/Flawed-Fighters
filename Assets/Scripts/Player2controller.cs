using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2controller : MonoBehaviour
{ 
    private bool isGrounded;
    private Rigidbody2D rb;
    //Public variables set in Unity Inspector
    public float xSpeed2;
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
        float xHat = new Vector2( Input.GetAxis("Player2Hor") , 0).normalized.x;
        float vx = xHat * xSpeed2;
        if (isGrounded) {
            rb.AddForce(transform.right * vx);
        } else {
            rb.AddForce(transform.right * vx);
        }


        float yHat = new Vector2(0, Input.GetAxis("Vertical2")).normalized.y;
        if (isGrounded && yHat == 1) {
            float vy = yHat * jumpStrength;
            isGrounded = false;
            rb.AddForce(transform.up * vy);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        //Get rid of this when no longer necessary
        Debug.Log(collision.gameObject.tag);
        isGrounded = collision.gameObject.tag == "Ground";
    }
}
