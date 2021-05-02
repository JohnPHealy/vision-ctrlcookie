
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private bool cancelJumpEnabled;

    private float moveDir;
    private Rigidbody2D myRB;
    public bool canJump;
    private SpriteRenderer mySprite;
    public float currentSpeed, currentVertSpeed;
    public Animator animator;
    private int moving = 0;
    public bool onPressable;
    public bool presseddowncorrect;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        mySprite = GetComponentInChildren<SpriteRenderer>();
    }

     void Update()
    {
        currentSpeed = myRB.velocity.x;
        currentVertSpeed = myRB.velocity.y;
        animator.SetFloat("speed", Mathf.Abs(currentSpeed + moving));
        animator.SetBool("canjump", canJump);
        animator.SetFloat("vertspeed", currentVertSpeed);
    }

    private void FixedUpdate()
    {

        if (moveDir > 0)
        {
            mySprite.flipX = false;
        }

        if (moveDir < 0)
        {
            mySprite.flipX = true;
        }

        var moveAxis = Vector3.right * moveDir;

        if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        }

        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (presseddowncorrect)
        {

            Debug.Log("detecteddown");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
    }

    public void Move(float moveAmt)
    {
        moveDir = moveAmt;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (canJump)
        {
            if (context.started)
            {
                myRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
        }

        if (context.canceled && cancelJumpEnabled)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
        }
    }

    public void Down(InputAction.CallbackContext context)
    {
        if (onPressable)
        { if (!presseddowncorrect)
            {
                presseddowncorrect = true;
            }

            else presseddowncorrect = false;

        }
       

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Platform"))
            this.transform.parent = col.transform;

        if (col.gameObject.tag == "Pressable")
        {
            onPressable = true;
            Debug.Log("Entered");        
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Platform"))
            this.transform.parent = null;

        if (col.gameObject.tag == "Pressable")
        {
            onPressable = false;
            Debug.Log("Left");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Platform"))
            this.transform.parent = col.transform;

        if (col.gameObject.tag == "Pressable")
        {
            onPressable = true;
            Debug.Log("Entered");
        }
    }


    void OnTriggerExit2D(Collider2D col)
{
    if (col.gameObject.name.Equals("Platform"))
            this.transform.parent = null;

        if (col.gameObject.tag == "Pressable")
        {
            onPressable = false;
            Debug.Log("Left");
        }
    }
}