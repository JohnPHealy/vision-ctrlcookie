using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoor : MonoBehaviour
{
    private bool gren;
    private bool played;
    [SerializeField] private AudioSource m_MyAudioSource;

    // Update is called once per frame
    void Update()
    {
        GameObject card = GameObject.Find("green keycard");

        GreenKeycard GreenKeycard = card.GetComponent<GreenKeycard>();

        gren = GreenKeycard.green;


        if (gren)
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
