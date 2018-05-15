using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_press5 : MonoBehaviour {

    /*        
     //        Developer Name: Travis Imhoff
     //         Contribution: Created Script
     //                Press5 fall and raise animations will play when trigger is entered and stop playing when trigger is exited.
     //                March 16, 2018
     //*/

    public GameObject press5;
    private Animator press5Anim;
    private bool Toggle = false;

    // Use this for initialization
    void Start()
    {

        press5Anim = press5.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        TogglePress5Anim();

    }

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = true;
        }
    }

    void TogglePress5Anim()
    {
        if (Toggle == true)
        {
            if (press5Anim.GetBool("press5Trigger") == false)
            {
                press5Anim.SetBool("press5Trigger", true);
            }

            else
            {
                press5Anim.SetBool("press5Trigger", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            Toggle = false;
            press5Anim.SetBool("press5Trigger", false);
        }
    }
}
