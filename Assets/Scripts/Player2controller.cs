using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2controller : MonoBehaviour
{ 
    public int stock;
    public int damage;
    private bool isGrounded;
    private Rigidbody2D rb;
    //Public variables set in Unity Inspector
    public float xSpeed2;
    public float jumpStrength;
    private bool hasCollided;
    private Vector3 respawnPos = new Vector3(-3.5f, 2, 0);
    private bool hasRespawned = false;
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
        if (hasRespawned) {
            transform.position = respawnPos;
            rb.gravityScale = 0;
            rb.velocity = new Vector2 (0,0);
            if (Input.GetAxis("Player2Hor") != 0 || Input.GetAxis("Vertical2") != 0){
                hasRespawned = false;
            }
        } else {
            rb.gravityScale = 4;
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
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Hitbox") {
            hasCollided = false;
        }
        if(collision.gameObject.tag == "BlastLine") {
            stock = stock - 1;
            damage = 0;
            transform.position = respawnPos;
            hasRespawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Hitbox" && hasCollided != true && hasRespawned == false){
            hasCollided = true;
            Debug.Log(collision.gameObject.GetComponent<Hithandler2>());
            int damageAmount = collision.gameObject.GetComponent<Hithandler2>().damage;
            float langley = collision.gameObject.GetComponent<Hithandler2>().launchVert;
            float langlex = collision.gameObject.GetComponent<Hithandler2>().launchHoriz;
            Debug.Log(langley + langlex);
            Debug.Log(damage);
            damage = damage + damageAmount;
            rb.AddForce(transform.up * (langley + (damage * 2)));
            rb.AddForce(transform.right * (langlex + (damage * 2)));
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //Get rid of this when no longer necessary
        Debug.Log(collision.gameObject.tag);
        isGrounded = collision.gameObject.tag == "Ground";
    }
}
