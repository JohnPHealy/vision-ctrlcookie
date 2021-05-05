using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueDoor : MonoBehaviour
{
    private bool bloo;
    private bool played;
    [SerializeField] private AudioSource m_MyAudioSource;

    // Update is called once per frame
    void Update()
    {
        GameObject card = GameObject.Find("blue keycard");

        BlueKeycard BlueKeycard = card.GetComponent<BlueKeycard>();

        bloo = BlueKeycard.blue;


        if (bloo)
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
