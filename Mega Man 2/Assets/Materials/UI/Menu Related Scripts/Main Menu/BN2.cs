using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name - Kaitlin Soter
 * 1/17/2018
 * Credit: Project & Portfolio 4 - Mega Man 2 group project
 * Purpose: Movement controls for the Start/Password scene
 */

public class BN2 : MonoBehaviour {

    //make sure to keep UnityEngine.SceneManagement in top

    //Arrow Function Variables
    int index = 0;
    private float yOffset = 1f;

    //Making Arrow blink continuously
    private void Start()
    {
        InvokeRepeating("ArrowBlinking", 0f, 0.17f);

        Cursor.visible = false; // Sets the mouse cursor to invisible
    }

    void Update()
    {

        //Arrow Function Code

        //If the player presses the S key, move the key down one
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (index <= 0)
            {
                index++;
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }
        }

        //If the player presses the W, move the key up one
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.y += yOffset;
                transform.position = position;
            }
        }

        //Scene Loading Code

        //If selecting Start, load the level selection menu
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (index == 0)
            {
                SceneManager.LoadScene("BossLevel");
            }
        }
        //If selecting Password, load the Password scene
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (index == 1)
            {
                SceneManager.LoadScene("PasswordInput");
            }
        }
    }

    //Blinking Code

    void ArrowBlinking()
    {
        if (this.GetComponent<MeshRenderer>().enabled == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (this.GetComponent<MeshRenderer>().enabled == false)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}