using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hithandler2 : MonoBehaviour
{
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
        fireAllow = true;
        hitTimeCounter = 0;
        parentTransform = gameObject.GetComponentInParent(typeof(Transform)) as Transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis ("Fire") >= 0.1 && fireAllow) {
            fireAllow = false;
            transform.localScale = new Vector3(atk1x, atk1y);
            transform.position = new Vector3 (atk1Pos.x + parentTransform.position.x, atk1Pos.y + parentTransform.position.y, 0);
            // transform.position = new Vector3 (parentTransform.position.x, parentTransform.position.y, 0);
        }
        
        if(hitTimeCounter <= hitTime1 && !fireAllow){
            hitTimeCounter++;
            Debug.Log("hit time count");
        } else if (!fireAllow) {
            transform.localScale = new Vector3(0.1f, 0.1f);
            hitTimeCounter = 0; 
            transform.position = new Vector3 (parentTransform.position.x - atk1Pos.x, parentTransform.position.y - atk1Pos.y, 0);
            fireAllow = true;
            Debug.Log ("hit timer reached");
        }
        // if(Input.GetAxis ("Fire") <= 0 && fireAllow) {
        //     fireAllow = false;
        //     transform.localScale = new Vector3(atk2x, atk2y);
        //     transform.position = new Vector3 (atk2Pos.x + parentTransform.position.x, atk2Pos.y + parentTransform.position.y, 0);
        //     // transform.position = new Vector3 (parentTransform.position.x, parentTransform.position.y, 0);
        // }
        
        // if(hitTimeCounter <= hitTime2 && !fireAllow){
        //     hitTimeCounter++;
        //     Debug.Log("hit time count");
        // } else if (!fireAllow) {
        //     transform.localScale = new Vector3(0.1f, 0.1f);
        //     hitTimeCounter = 0; 
        //     transform.position = new Vector3 (parentTransform.position.x - atk2Pos.x, parentTransform.position.y - atk2Pos.y, 0);
        //     fireAllow = true;
        //     Debug.Log ("hit timer reached");
        // }
                parentTransform = gameObject.GetComponentInParent(typeof(Transform)) as Transform;
                // Debug.Log(parentTransform.position);
    }
}
