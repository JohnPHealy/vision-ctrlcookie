using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeycard : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    public bool red;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            red = true;
            Destroy(m_SpriteRenderer);
        }

    }
}
