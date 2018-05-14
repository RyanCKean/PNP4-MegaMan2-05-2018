using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMan_Animation : MonoBehaviour {

    //*
    //    Devloper Name: Malik Smith
    //    Contribution: Created Script
    //    Bubble Man will be the only Robot Master to have slow jump animations when Mega Man enters the room
    //    May 13, 2018
    //*/

    public GameObject metalMan;
    private Animator jumpAnim;
    private bool Toggle = false;
    private Animator anim;

    // Use this for initialization
    void Start()
    {

        jumpAnim = metalMan.GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            anim.SetBool("isAttacked", true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            anim.SetBool("isAttacked", false);
        }

        ToggleJumpAnim();

    }

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.name.Contains("MegaMan"))
        {
            Toggle = true;
            ;
        }
    }


    void ToggleJumpAnim()
    {
        if (Toggle == true)
        {
            if (jumpAnim.GetBool("rightTrigger") == false)
            {
                jumpAnim.SetBool("rightTrigger", true);
            }
            else
            {
                jumpAnim.SetBool("rightTrigger", false);
            }

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
            jumpAnim.SetBool("rightTrigger", false);

            Toggle = false;
            jumpAnim.SetBool("leftTrigger", false);
        }
    }
}
