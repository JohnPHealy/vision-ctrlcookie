using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    private bool ridd;
    private bool played;
    [SerializeField] private AudioSource m_MyAudioSource;

    // Update is called once per frame
    void Update()
    {
        GameObject card = GameObject.Find("red keycard");

        RedKeycard RedKeycard = card.GetComponent<RedKeycard>();

        ridd = RedKeycard.red;


        if (ridd)
        {
            if (!m_MyAudioSource.isPlaying && !played)
            {
                played = true;
                m_MyAudioSource.Play();
            }

            Destroy(gameObject, 2);

        }
    }
}
