using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hithandler2 : MonoBehaviour
{
    private int facingRight;
    public bool atk1;
    public bool atk2;
    public int damage;
    public float atk1x;
    public float atk1y;
    public float hitTime1;
    private float hitTimeCounter;
    public float launchVert;
    public float launchHoriz;
    public Vector2 atk1Pos;
    private Vector2 boxPos = new Vector2 (0, 0);
    private Transform parentTransform;
    private bool fireAllow;
    public int damage2;
    public float atk2x;
    public float atk2y;
    public float hitTime2;
    public float launchHoriz2;
    public float launchVert2;
    public Vector2 atk2Pos;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = 1;
        atk1 = true;
        atk2 = true;
        fireAllow = true;
        hitTimeCounter = 0;
        parentTransform = gameObject.GetComponentInParent(typeof(Transform)) as Transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xHat = new Vector2( Input.GetAxis("Player2Hor") , 0).normalized.x;
            if (xHat > 0){
                facingRight = 1;
            }
            if (xHat < 0){
                facingRight = -1;
            }
        if(Input.GetAxis ("Fire") >= 0.1f && fireAllow) {
            fireAllow = false;
            transform.localScale = new Vector3(atk1x, atk1y);
            transform.position = new Vector3 ((atk1Pos.x + parentTransform.position.x) * facingRight, atk1Pos.y + parentTransform.position.y, 0);
            // transform.position = new Vector3 (parentTransform.position.x, parentTransform.position.y, 0);
        } 
        // else if (Input.GetAxis ("Fire") <= -0.1f && fireAllow) {
        //     fireAllow = false;
        //     transform.localScale = new Vector3 (atk2x, atk2y);
        //     transform.position = new Vector3 ((atk2Pos.x + parentTransform.position.x) * facingRight, atk2Pos.y + parentTransform.position.y, 0);
        // }
        
        if(hitTimeCounter <= hitTime1 && !fireAllow){
            hitTimeCounter++;
            Debug.Log("hit time count");
        } else if (!fireAllow && atk1) {
            transform.localScale = new Vector3(0.1f, 0.1f);
            hitTimeCounter = 0; 
            transform.position = new Vector3 (parentTransform.position.x - atk1Pos.x, parentTransform.position.y - atk1Pos.y, 0);
            fireAllow = true;
            Debug.Log ("hit timer reached");
        } 
        // else {
        //     transform.localScale = new Vector3(0.1f, 0.1f);
        //     hitTimeCounter = 0; 
        //     transform.position = new Vector3 (parentTransform.position.x - atk2Pos.x, parentTransform.position.y - atk2Pos.y, 0);
        //     fireAllow = true;
        //     Debug.Log ("hit timer reached");}
        //         parentTransform = gameObject.GetComponentInParent(typeof(Transform)) as Transform;
        //         // Debug.Log(parentTransform.position);
    }
}
