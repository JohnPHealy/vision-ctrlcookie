using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doordestroy : MonoBehaviour
{
    public bool destroyself;


    // Update is called once per frame
    void Update()
    {
        GameObject lampchanger = GameObject.Find("lamp changer"); //has to be false
        turnlampon changer = lampchanger.GetComponent<turnlampon>();
        destroyself = changer.alltrue;


        if (destroyself)
        {
            Destroy(gameObject);
        }

    }
}
