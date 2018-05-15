using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name - Kaitlin Soter
 * 1/17/2018
 * Credit: Project & Portfolio 4 - Mega Man 2 group project
 * Purpose: Movement controls for the Main Menu
 */

public class ButtonNavigation : MonoBehaviour {

    //make sure to keep UnityEngine.SceneManagement in top

    //Arrow Function Variables
    int index = 0; //The int that holds the location of the buttons
    private float yOffset = 1.45f; //How far the sphere will travel on the yaxis when the button is pressed

    //Making Arrow blink continuously
    private void Start()
    {
        InvokeRepeating("ArrowBlinking", 0f, 0.17f); //Making the arrow blink forever
        Cursor.visible = false; // Sets the mouse cursor to invisible
    }

    void Update()
    {

//Arrow Function Code

        //If the player presses the S key, move the key down one
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (index <= 0) //is the player on Normal?
            {
                index++; //Then increase the index by 1
                Vector2 position = transform.position; //Then get the current position
                position.y -= yOffset; //and subtract that position by the yOffset
                transform.position = position; //and set our new position to the answer
            }
        }

        //If the player presses the W, move the key up one
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (index > 0) //is the player on Difficult?
            {
                index--; //Then decrease the index by 1
                Vector2 position = transform.position; //Then get the current position
                position.y += yOffset; //and add that position to the yOffset
                transform.position = position; //and set our new position to the answer
            }
        }

//Scene Loading Code

        //If selecting normal, load the boss selection scene for Normal mode
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (index == 0) //is the player on Normal?
            {
                SceneManager.LoadScene("StartPassword");
            }
        }
        //If selecting Difficult, load the boss selection scene for Difficult mode
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (index == 1) //is the player on difficult?
            {
                SceneManager.LoadScene("StartPassword");
            }
        }
    }

//Blinking Code

    void ArrowBlinking() //creating the function/string for making the arrow blink
    {
        //If the mesh renderer on the game object is enabled, then set it to be disabled.
        if (this.GetComponent<MeshRenderer>().enabled == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        //now to get it to flash, we do the opposite.
        else if (this.GetComponent<MeshRenderer>().enabled == false)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}