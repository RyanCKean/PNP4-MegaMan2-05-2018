using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name - Kaitlin Soter
 * 1/17/2018
 * Credit: Project & Portfolio 4 - Mega Man 2 group project, Received Help from Justin Gallo for the function "BoxSelection"
 * Purpose: Holds the function to move the selectboss prefab and show red pins when player hits enter
 */

public class PasswordScript : MonoBehaviour
{

    [SerializeField] Transform selectBoss; // this holds the SelectBoss prefab that shows the player what's highlighted
    public GameObject[] RedPins; // array that holds all the red pin locations
    public GameObject[] tilePositions; // array that holds all the grid space positions
    private int pinCount = 0; // the int that counts how many pins I have on the board
    int boxIndex = 0;
    bool CorrectPW; // to check if the password is correct
    [SerializeField] TextMesh countingPins; //to update the pin count number on screen

    // Use this for initialization
    void Start()
    {

        selectBoss = gameObject.GetComponent<Transform>(); //Setting the transform of the prefab

        Cursor.visible = false; // Sets the mouse cursor to invisible
    }

    // Update is called once per frame
    void Update()
    {
        BoxSelection(); //Calling these functions to check them every frame
        BoxMarked();


        if (CorrectPW == true) //If the password is correct, the load the boss selection level
        {
            SceneManager.LoadScene("BossLevel");
        }

        // checking to see if the password is correct. If it's not then reload the start password scene
        if (pinCount >= 9)
        {
            if (tilePositions[1].GetComponent<BoxCheck>().boxChecked == true && tilePositions[5].GetComponent<BoxCheck>().boxChecked == true && tilePositions[11].GetComponent<BoxCheck>().boxChecked == true && tilePositions[14].GetComponent<BoxCheck>().boxChecked == true && tilePositions[15].GetComponent<BoxCheck>().boxChecked == true && tilePositions[16].GetComponent<BoxCheck>().boxChecked == true && tilePositions[18].GetComponent<BoxCheck>().boxChecked == true && tilePositions[20].GetComponent<BoxCheck>().boxChecked == true && tilePositions[23].GetComponent<BoxCheck>().boxChecked == true)
            {
                CorrectPW = true;
                Debug.Log(CorrectPW);
            }
            else
            {
                CorrectPW = false;
                if (CorrectPW == false)
                {
                    SceneManager.LoadScene("StartPassword");
                }
            }
        }

        //updating the text mesh on the number to accurately reflect the numbers of pins used
        if (pinCount == 9)
        {
            countingPins.GetComponent<TextMesh>().text = "";
        }

        if (pinCount == 8)
        {
            countingPins.GetComponent<TextMesh>().text = "1";
        }
        if (pinCount == 7)
        {
            countingPins.GetComponent<TextMesh>().text = "2";
        }
        if (pinCount == 6)
        {
            countingPins.GetComponent<TextMesh>().text = "3";
        }
        if (pinCount == 5)
        {
            countingPins.GetComponent<TextMesh>().text = "4";
        }
        if (pinCount == 4)
        {
            countingPins.GetComponent<TextMesh>().text = "5";
        }
        if (pinCount == 3)
        {
            countingPins.GetComponent<TextMesh>().text = "6";
        }
        if (pinCount == 2)
        {
            countingPins.GetComponent<TextMesh>().text = "7";
        }
        if (pinCount == 1)
        {
            countingPins.GetComponent<TextMesh>().text = "8";
        }
        if (pinCount == 0)
        {
            countingPins.GetComponent<TextMesh>().text = "9";
        }
    }

    private void BoxSelection()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (boxIndex != 4 || boxIndex != 9 || boxIndex != 14 || boxIndex != 19 || boxIndex != 24)
            {
                boxIndex += 1;

                if (boxIndex > 24)
                {
                    boxIndex = 24;
                }
                selectBoss.position = tilePositions[boxIndex].GetComponent<Transform>().position;
            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (boxIndex < 20)
            {
                boxIndex += 5;

                selectBoss.position = tilePositions[boxIndex].GetComponent<Transform>().position;
            }
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (boxIndex > 4)
            {
                boxIndex -= 5;

                selectBoss.position = tilePositions[boxIndex].GetComponent<Transform>().position;
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (boxIndex != 0 || boxIndex != 5 || boxIndex != 10 || boxIndex != 15 || boxIndex != 20)
            {
                boxIndex -= 1;

                if (boxIndex < 0)
                {
                    boxIndex = 0;
                }

                selectBoss.position = tilePositions[boxIndex].GetComponent<Transform>().position;
            }
        }
    }

    private void BoxMarked()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (boxIndex == 0)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[0].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }

            else if (boxIndex == 1)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[1].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 2)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[2].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 3)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[3].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 4)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[4].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 5)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[5].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 6)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[6].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 7)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[7].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 8)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[8].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 9)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[9].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 10)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[10].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 11)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[11].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 12)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[12].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 13)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[13].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 14)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[14].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 15)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[15].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 16)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[16].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 17)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[17].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 18)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[18].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 19)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[19].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 20)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[20].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 21)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[21].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 22)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[22].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 23)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[23].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }


            else if (boxIndex == 24)
            {
                if (tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked == false)
                {
                    tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked = true; // setting the box on that position to being used
                    Debug.Log(tilePositions[boxIndex].GetComponent<BoxCheck>().boxChecked); // adding a debug to make sure it's working
                    RedPins[24].SetActive(true); // make the red pin visible
                    pinCount++; // add the now visible pin to the int
                    Debug.Log(pinCount); // debug to check how many pins I currently am storing in the pin count int
                }
            }
        }
    }
}
