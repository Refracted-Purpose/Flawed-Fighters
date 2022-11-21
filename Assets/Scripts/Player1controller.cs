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
    private bool hasCollided;
    //initialize private variables in start
    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame, Fixed used for physics
    void FixedUpdate()
    {
        float xHat = new Vector2( Input.GetAxis("Horizontal1") , 0).normalized.x;
        float vx = xHat * xSpeed;
        if (isGrounded) {
            rb.AddForce(transform.right * vx);
        } else {
            rb.AddForce(transform.right * vx);
        }


        float yHat = new Vector2(0, Input.GetAxis("Vertical1")).normalized.y;
        if (isGrounded && yHat == 1) {
            float vy = yHat * jumpStrength;
            isGrounded = false;
            rb.AddForce(transform.up * vy);
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Hitbox") {
            hasCollided = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Hitbox" && hasCollided != true){
            hasCollided = true;
            Debug.Log(collision.gameObject.GetComponent<Hithandler2>());
            float langley = collision.gameObject.GetComponent<Hithandler2>().launchVert;
            float langlex = collision.gameObject.GetComponent<Hithandler2>().launchHoriz;
            Debug.Log(langley + langlex);
            rb.AddForce(transform.up * langley);
            rb.AddForce(transform.right * langlex);

        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //Get rid of this when no longer necessary
        Debug.Log(collision.gameObject.tag);
        isGrounded = collision.gameObject.tag == "Ground";
    }
}
