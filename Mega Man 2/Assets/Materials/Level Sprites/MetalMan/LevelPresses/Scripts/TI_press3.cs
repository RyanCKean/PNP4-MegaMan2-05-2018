using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_press3 : MonoBehaviour {

    /*        
     //        Developer Name: Travis Imhoff
     //         Contribution: Created Script
     //                Press3 fall and raise animations will play when trigger is entered and stop playing when trigger is exited.
     //                March 16, 2018
     //*/

    public GameObject press3;
    private Animator press3Anim;
    private bool Toggle = false;

    // Use this for initialization
    void Start()
    {

        press3Anim = press3.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        TogglePress3Anim();

    }

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = true;
        }
    }

    void TogglePress3Anim()
    {
        if (Toggle == true)
        {
            if (press3Anim.GetBool("press3Trigger") == false)
            {
                press3Anim.SetBool("press3Trigger", true);
            }

            else
            {
                press3Anim.SetBool("press3Trigger", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = false;
            press3Anim.SetBool("press3Trigger", false);
        }
    }
}
