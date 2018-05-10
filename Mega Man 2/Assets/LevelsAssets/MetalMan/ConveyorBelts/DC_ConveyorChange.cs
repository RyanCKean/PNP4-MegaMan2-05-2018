using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC_ConveyorChange : MonoBehaviour {
    /*
     * This Script was created by Dominic Christiano to change the direction the conveyor moves the player.
     * It also switches the animation of the conveyor to show the appropriate sprites and animation.
    */
    Animator anim;  //gets animator
    public int timer; // timer for right movement
    public GameObject rightF, leftF; // the two triggers that have the area effector on them.
    bool swapping; // used below to start the left timer
    public int altTimer; // left timer
    bool isRight, isLeft; // bools that are conditions for the transitions to the different states 



    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    void Awake()
    {
        isLeft = true;
        swapping = false;
        rightF.SetActive(false);
        leftF.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
       
        ChangeDirection();
        ChangeAnimation();
	}

    //Changes the direction the conveyor moves the player
    void ChangeDirection()
    {
        //Metal Man's conveyor switches about every 5 seconds. 250 is about 5 seconds long i.e. timer >= 42. A good test number is 100. 
        timer++;
        if (timer >= 250)
        {
            isLeft = false;
            //Debug.Log("Going Left");
            leftF.SetActive(false);
            rightF.SetActive(true);
            timer = 0;
            swapping = true;
            isRight  = true;

        } 

        else if (swapping == true)
        {
           // Debug.Log("alt started");
            altTimer++;
            timer--;
        }
        //Metal Man's conveyor switches about every 5 seconds. 250 is about 5 seconds long i.e. altTimer >= 425. A good test number is 100. 
        if (altTimer >= 250)
        {
            isRight = false;
           // Debug.Log("Going Right");
            leftF.SetActive(true);
            rightF.SetActive(false);
            timer = 0;
            altTimer = 0;
            swapping = false;
            isLeft = true;

        }

    }
    // this sets the bool parameters in the animator. If the bool is true it sets it to true in the animator and vice versa. 
    void ChangeAnimation()
    {
        if (isLeft == true)
        {
            anim.SetBool("isLeft", true);
        }
        if (isRight == true)
        {
            anim.SetBool("isRight", true);
        }
        if (isLeft == false)
        {
            anim.SetBool("isLeft", false);
        }
        if (isRight == false)
        {
            anim.SetBool("isRight", false);
        }
    }


}
