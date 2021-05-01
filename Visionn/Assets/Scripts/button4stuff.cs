using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button4stuff : MonoBehaviour
{
    public Animator animator;
    public bool var;
    public bool isPlayer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            GameObject Player = GameObject.Find("Player");

            PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();

            var = playerMovement.presseddowncorrect;
            animator.SetBool("Buttoned", var);
        }
        //Debug.Log(var);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }
}
