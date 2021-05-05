using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnlampon : MonoBehaviour
{
    public Animator animator;
    public bool twoistrue;
    public bool twelveistrue;
    public bool fiveistrue;

    public bool sevenisfalse;
    public bool fourisfalse;
    public bool sixisfalse;

    public bool alltrue;


    // Update is called once per frame
    void Update()
    {
        
   
        GameObject LightSwitch2 = GameObject.Find("LightSwitch (2)");  //has to be true
        buttonontrigger2 lamp2 = LightSwitch2.GetComponent<buttonontrigger2>();
        twoistrue = lamp2.var1;

        GameObject LightSwitch12 = GameObject.Find("LightSwitch (12)"); //has to be true
        buttonontrigger12 lamp12 = LightSwitch12.GetComponent<buttonontrigger12>();
        twelveistrue = lamp12.var;

        GameObject LightSwitch5 = GameObject.Find("LightSwitch (5)"); //has to be true
        buttonontrigger5 lamp5 = LightSwitch5.GetComponent<buttonontrigger5>();
        fiveistrue = lamp5.var;

        GameObject LightSwitch7 = GameObject.Find("LightSwitch (7)"); //has to be false
        buttonontrigger7 lamp7 = LightSwitch7.GetComponent<buttonontrigger7>();
        sevenisfalse = lamp7.var;

        GameObject LightSwitch4 = GameObject.Find("LightSwitch (4)"); //has to be false
        buttonontrigger4 lamp4 = LightSwitch4.GetComponent<buttonontrigger4>();
        fourisfalse = lamp4.var;

        GameObject LightSwitch6 = GameObject.Find("LightSwitch (6)"); //has to be false
        buttonontrigger6 lamp6 = LightSwitch6.GetComponent<buttonontrigger6>();
        sixisfalse = lamp6.var;



         if (twoistrue && twelveistrue && fiveistrue)
        {   if (sevenisfalse == false && fourisfalse == false && sixisfalse == false) 
            {
                alltrue = true;
            }
        }
        else
        {
            alltrue = false;
        }

        animator.SetBool("allcorrect", alltrue);
        
    }

}
