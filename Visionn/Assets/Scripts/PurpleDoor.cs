using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDoor : MonoBehaviour
{
    public bool destroyself;
    private bool played;
    [SerializeField] private AudioSource m_MyAudioSource;

    // Update is called once per frame
    void Update()
    {
        GameObject lampchanger = GameObject.Find("lamp changer"); //has to be false
        turnlampon changer = lampchanger.GetComponent<turnlampon>();
        destroyself = changer.alltrue;


        if (destroyself)
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
