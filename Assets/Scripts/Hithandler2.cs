using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hithandler2 : MonoBehaviour
{
    public int damage;
    public float atk1x;
    public float atk1y;
    public float hitTime;
    private float hitTimeCounter;
    public float launchVert;
    public float launchHoriz;
    public Vector2 atk1Pos;
    private Vector2 boxPos = new Vector2 (0, 0);
    private Transform parentTransform;
    private bool fireAllow;
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
        if(Input.GetAxis ("Fire") != 0 && fireAllow) {
            fireAllow = false;
            transform.localScale = new Vector3(atk1x, atk1y);
            transform.position = new Vector3(atk1Pos.x + parentTransform.position.x, atk1Pos.y + parentTransform.position.y, 0);
        }
        if(hitTimeCounter <= hitTime){
            hitTimeCounter++;
        }
        if(hitTimeCounter == hitTime){
            transform.localScale = new Vector3(0.1f, 0.1f);
            hitTimeCounter = 0; 
            transform.position = parentTransform.position;
            fireAllow = true;
        }
        if(hitTimeCounter >= hitTime){
            hitTimeCounter = 0;
        }
                parentTransform = gameObject.GetComponentInParent(typeof(Transform)) as Transform;
                // Debug.Log(parentTransform.position);
    }
}
