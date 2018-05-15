using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_press1 : MonoBehaviour {

    /*        
    //        Developer Name: Travis Imhoff
    //         Contribution: Created Script
    //                Press1 fall and raise animations will play when trigger is entered and stop playing when trigger is exited.
    //                March 16, 2018
    //*/

    public GameObject press1;
    private Animator press1Anim;
    private bool Toggle = false;

	// Use this for initialization
	void Start () {

        press1Anim = press1.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        TogglePress1Anim();
		
	}

    void OnTriggerEnter2D(Collider2D entity)
    {
        if(entity.tag == "Player")
        {
            Toggle = true;
        }
    }

    void TogglePress1Anim()
    {
        if (Toggle == true)
        {
            if(press1Anim.GetBool("press1Trigger") == false)
            {
                press1Anim.SetBool("press1Trigger", true);
            }

            else
            {
                press1Anim.SetBool("press1Trigger", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D entity)
    {
        if(entity.tag == "Player")
        {
            Toggle = false;
            press1Anim.SetBool("press1Trigger", false);
        }
    }
}
