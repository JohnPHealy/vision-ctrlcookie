using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKeycard : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    public bool green;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            green = true;
            Destroy(m_SpriteRenderer);
        }

    }
}
