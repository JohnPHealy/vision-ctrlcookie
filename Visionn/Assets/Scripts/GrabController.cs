using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrabController : MonoBehaviour 
{
    public bool dnkey;
    public Transform grabDetect;
    public Transform itemHolder;
    public float rayDist;

    // Update is called once per frame
    void Update() 
    {
        GameObject Player = GameObject.Find("Player");
        PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
        dnkey = playerMovement.dnkey;

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null)  //only works when camera zones are turned off for some reasonnnnnnnnnn
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAA");
            if(dnkey)
            {
                grabCheck.collider.gameObject.transform.parent = itemHolder;
                grabCheck.collider.gameObject.transform.position = itemHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    
}
