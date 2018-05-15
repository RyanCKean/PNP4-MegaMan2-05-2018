using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_MetalManJumpRight : MonoBehaviour {

    /*        
    //        Developer Name: Travis Imhoff
    //         Contribution: Created Script
    //                Metal Man will jump from the right side of the screen to the left side when the trigger is entered
    //                March 16, 2018
    //*/


    public GameObject metalMan;
    private Animator rightJumpAnim;
    private bool Toggle = false;

	// Use this for initialization
	void Start () {

        rightJumpAnim = metalMan.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        ToggleRightJumpAnim();
		
	}

    void OnTriggerEnter2D(Collider2D entity)
    { 
        if (entity.name.Contains("MegaMan"))
        {
            Toggle = true;
;       }
    }


    void ToggleRightJumpAnim()
    {
        if (Toggle == true)
        {
            if(rightJumpAnim.GetBool("rightTrigger") == false)
            {
                rightJumpAnim.SetBool("rightTrigger", true);
            }
            else
            {
                rightJumpAnim.SetBool("rightTrigger", false);
            }

        }
    }

    void OnTriggerExit2D(Collider2D entity)
    {
        if (entity.name.Contains("MegaMan"))
        {
            Toggle = false;
            rightJumpAnim.SetBool("rightTrigger", false);
        }
    }
}
