using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_press2 : MonoBehaviour {

    /*        
     //        Developer Name: Travis Imhoff
     //         Contribution: Created Script
     //                Press2 fall and raise animations will play when trigger is entered and stop playing when trigger is exited.
     //                March 16, 2018
     //*/


    public GameObject press2;
    private Animator press2Anim;
    private bool Toggle = false;

    // Use this for initialization
    void Start()
    {

        press2Anim = press2.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        TogglePress2Anim();

    }

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = true;
        }
    }

    void TogglePress2Anim()
    {
        if (Toggle == true)
        {
            if (press2Anim.GetBool("press2Trigger") == false)
            {
                press2Anim.SetBool("press2Trigger", true);
            }

            else
            {
                press2Anim.SetBool("press2Trigger", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = false;
            press2Anim.SetBool("press2Trigger", false);
        }
    }
}
