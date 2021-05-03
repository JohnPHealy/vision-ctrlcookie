using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonontrigger3 : MonoBehaviour
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
            animator.SetBool("var2", var);
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
