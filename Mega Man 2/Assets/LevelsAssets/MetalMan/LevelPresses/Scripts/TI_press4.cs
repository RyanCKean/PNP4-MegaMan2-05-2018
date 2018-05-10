using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_press4 : MonoBehaviour {

    /*        
     //        Developer Name: Travis Imhoff
     //         Contribution: Created Script
     //                Press4 fall and raise animations will play when trigger is entered and stop playing when trigger is exited.
     //                March 16, 2018
     //*/

    public GameObject press4;
    private Animator press4Anim;
    private bool Toggle = false;

    // Use this for initialization
    void Start()
    {

        press4Anim = press4.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        TogglePress4Anim();

    }

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = true;
        }
    }

    void TogglePress4Anim()
    {
        if (Toggle == true)
        {
            if (press4Anim.GetBool("press4Trigger") == false)
            {
                press4Anim.SetBool("press4Trigger", true);
            }

            else
            {
                press4Anim.SetBool("press4Trigger", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = false;
            press4Anim.SetBool("press4Trigger", false);
        }
    }
}
