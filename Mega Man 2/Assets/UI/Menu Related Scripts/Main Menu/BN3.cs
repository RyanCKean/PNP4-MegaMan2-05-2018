using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name - Kaitlin Soter
 * 1/17/2018
 * Credit: Project & Portfolio 4 - Mega Man 2 group project
 * Purpose: Movement controls for the Game Over scene
 */

public class BN3 : MonoBehaviour {
    //make sure to keep UnityEngine.SceneManagement in top

    // Camera moving functions
    public GameObject MainCam; //Calling the Camera
    public Animator MainCamAnim; //Getting the animation from the camera
    private bool transition = false; //toggling the boolean to start the animation

    //Arrow Function Variables
    int index = 0; //The int that holds the location of the buttons
    int MenuChoices = 3; //The int that holds the amount of menu choices
    private float yOffset = 1.3f; //How far the sphere will travel on the yaxis when the button is pressed

    //Making Arrow blink continuously
    private void Start()
    {
        InvokeRepeating("ArrowBlinking", 0f, 0.17f); //Making the arrow blink forever
        MainCamAnim = MainCam.GetComponent<Animator>(); //Getting the animator component
        transition = true; //Setting the boolean to true so that it starts as soon as the scene loads
    }

    void Update()
    {
        //Calling the function responsible for the animation
        TransitionCamera();

        //Arrow Function Code

        //If the player presses the S key, move the key down one
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (index <= MenuChoices - 1) //is the player on Continue or Stage Select?
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
            if (index > 0) //Is the player not at the top of the index? (Continue)
            {
                index--; //Then decrease the index by 1
                Vector2 position = transform.position; //Then get the current position
                position.y += yOffset; //and add that position to the yOffset
                transform.position = position; //and set our new position to the answer
            }
        }

        //Scene Loading Code

        //If selecting Continue, load the level they died on
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 0) //Is the player on Continue?
            {
                SceneManager.LoadScene("TestScene");
            }
        }
        //If selecting Stage Select, load the Boss Selection Scene
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 1) //Is the player on Stage Select?
            {
                SceneManager.LoadScene("BossLevel");
            }
        }
        //If selecting Password, load the Password Scene
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 2) //Is the player on Password?
            {
                SceneManager.LoadScene("PasswordInput");
            }
        }
    }

    //Creating the function responsible for the animation
    void TransitionCamera()
    {
        if(transition == true) //If the bool is set to true
        {
            MainCamAnim.SetBool("transition", true); //Then call the Animator component and set the boolean within the animation to true
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