using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContro : MonoBehaviour
{
    public float horizontal;
    public float MaxSpeed = 5f;
    public bool facingRight = true;
    public bool bGrounded = false;
    public float jumpForce = 500f;
    public float moveForce = 100f;
    public Rigidbody2D rigidbody;

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
        rigidbody.AddForce(Vector2.right * horizontal * moveForce);
       
        if (horizontal * rigidbody.velocity.x < MaxSpeed)
            rigidbody.AddForce(Vector2.right * horizontal * moveForce);
        if (Mathf.Abs(rigidbody.velocity.x) > MaxSpeed)
            rigidbody.velocity = new Vector2(Mathf.Sign(rigidbody.velocity.x) * MaxSpeed, rigidbody.velocity.y);
        
        if (horizontal > 0 && !facingRight)
        {
            flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            flip();
        }


        bGrounded = Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        bool mJump = false;
        
        if (bGrounded)
        {
            mJump = Input.GetButtonDown("Jump");
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
