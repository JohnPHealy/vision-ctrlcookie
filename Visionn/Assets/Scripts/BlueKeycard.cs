using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeycard : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    public bool blue;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            blue = true;
            Destroy(m_SpriteRenderer);
        }

    }
}
