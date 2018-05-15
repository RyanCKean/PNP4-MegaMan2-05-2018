using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_MetalManJumpLeft : MonoBehaviour {

    /*        
    //        Developer Name: Travis Imhoff
    //         Contribution: Created Script
    //                Metal Man will jump from the left side of the screen to the right side when the trigger is entered
    //                March 16, 2018
    //*/

    public GameObject metalMan;
    private Animator jumpAnim;
    private bool Toggle = false;

    // Use this for initialization
    void Start()
    {

        jumpAnim = metalMan.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        ToggleJumpAnim();

    }

    void OnTriggerEnter2D(Collider2D entity)
    {
            if (entity.name.Contains("MegaMan"))
            {
                Toggle = true;
            }
    }


    void ToggleJumpAnim()
    {
        if (Toggle == true)
        {
            if (jumpAnim.GetBool("leftTrigger") == false)
            {
                jumpAnim.SetBool("leftTrigger", true);
            }
            else
            {
                jumpAnim.SetBool("leftTrigger", false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.name.Contains("MegaMan"))
        {
            Toggle = false;
            jumpAnim.SetBool("leftTrigger", false);
        }
    }
}
