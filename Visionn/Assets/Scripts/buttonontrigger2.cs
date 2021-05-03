
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonontrigger2 : MonoBehaviour
{
    public Animator animator;
    public bool var1;
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

            var1 = playerMovement.presseddowncorrect;
            animator.SetBool("var1", var1);
        }
        //Debug.Log(var);


    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isPlayer = false;
        }
    }
}
