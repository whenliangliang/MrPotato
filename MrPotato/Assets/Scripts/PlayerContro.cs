using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContro : MonoBehaviour
{
    float horizontal;
    float MaxSpeed = 5f;
    bool facingRight = true;
    bool bGroundCheck = false;
    float jumpForce = 500f;
    float moveForce = 100f;
    Rigidbody2D rigidbody;
    Transform mGroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //移动
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontal * moveForce);
       
        if (horizontal * GetComponent<Rigidbody2D>().velocity.x < MaxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontal * moveForce);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > MaxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        
        if (horizontal > 0 && !facingRight)
        {
            flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            flip();
        }
       
        
        Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        bool mJump = false;
        
        if (mGroundCheck)
        {
            mJump = Input.GetKeyDown(KeyCode.Space);
            if (mJump)
            {
                Vector2 upForce = new Vector2(0f, jumpForce);

                rigidbody.AddForce(upForce);
                mJump = false;
            }
            
           
        }
        

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
