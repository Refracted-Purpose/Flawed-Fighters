using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{  private bool facingRight;
    private SpriteRenderer spriteCran;
    // Start is called before the first frame update
    void Start()
    {
    spriteCran = GetComponent<SpriteRenderer>();
    facingRight = true;
    }

    // Update is called once per frame
    void Update()  
    {
        float xHat = new Vector2( Input.GetAxis("Player2Hor") , 0).normalized.x;
            if (xHat > 0){
                facingRight = true;
            }
            if (xHat < 0){
                facingRight = false;
            }
    if (facingRight) {
        spriteCran.flipX = true;
    }
    else {
        spriteCran.flipX = false;
    }
    }
}
