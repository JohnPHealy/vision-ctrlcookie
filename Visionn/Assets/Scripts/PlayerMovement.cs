//it's not really movement anymore and rather is all of the player but oh well

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
    [SerializeField] AudioSource audioData;
    [SerializeField] AudioSource audioDown;
    [SerializeField] AudioSource audioFell;


    private float moveDir;
    private Rigidbody2D myRB;
    public bool canJump;
    private SpriteRenderer mySprite;
    public float currentSpeed, currentVertSpeed;
    public Animator animator;
    private int moving = 0;
    public bool onPressable;
    public bool presseddowncorrect, dnkey, onKey;
    private bool bluepickup, redpickup, played, playedcheck;
    


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

        if(currentVertSpeed < -0.5 && canJump && !playedcheck)
        {
            playedcheck = true;
            audioFell.Play(0);

        }

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
            playedcheck = false;
        }

        if (bluepickup)
        {
            jumpForce = 10;
        }
        if (redpickup)
        {
            moveSpeed = 13;
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
                audioData.Play(0);
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
                if (!played)
                {
                    audioDown.Play(0);
                }
                played = true;
                presseddowncorrect = true;
            }

            else if (presseddowncorrect)
            {
                if (played)
                {
                    played = false;
                }
                presseddowncorrect = false;
            }
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

        if (col.gameObject.tag == "Key")
        {
            onKey = true;
            Debug.Log("onkey");
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
            if (col.gameObject.tag == "Key")
            {
                onKey = false;
                Debug.Log("offkey");
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

        if (col.gameObject.tag == "pickupblue")
        {
            bluepickup = true;
        }
        if (col.gameObject.tag == "pickupred")
        {
            redpickup = true;
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