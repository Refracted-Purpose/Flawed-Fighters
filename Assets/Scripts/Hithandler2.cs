using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hithandler2 : MonoBehaviour
{
    public float LaunchStrength;
    public float atk1x;
    public float atk1y;
    public float hitTime;
    private float hitTimeCounter;
    public float launchVert;
    public float launchHoriz;
    // Start is called before the first frame update
    void Start()
    {
        hitTimeCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxis ("Fire") != 0) {
            transform.localScale = new Vector3(atk1x, atk1y);
        }
        if(hitTimeCounter <= hitTime){
            hitTimeCounter++;
        }
        if(hitTimeCounter == hitTime){
            transform.localScale = new Vector3(0.1f, 0.1f);
            hitTimeCounter = 0; 
        }
        if(hitTimeCounter >= hitTime){
            hitTimeCounter = 0;
        }
    }
}
