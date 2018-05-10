using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Name: Josiah Dewhirst
//Date: 4/14/2018
//Purpose: Adds funtionality to the pause menu UI element.

public class pauseScript : MonoBehaviour {
	
	//Boolean to check if the game is paused or not
	public bool paused;
	//UI reference to the pause menu
	public GameObject pauseMenuUI;
	//Placeholder for currently held lives
	public Text pauseLives;
	//UI Panel that holds life elements
	public GameObject livesPanel;
	//UI Panel that holds the first page of ability elements
	public GameObject inventoryPanel1;
	//Boolean to check which page the pause menu is on
	public bool menuSwitch;
	//Audio Source when game is paused and un-paused
	public AudioSource pauseSound;
	//Audio Source that plays when switching between menu pages
	public AudioSource nextSound;

	// Use this for initialization
	void Start () {

		//at start, game is not paused, pause menu and dependant elements are not visable
		paused = false;
		pauseMenuUI.SetActive (false);
		livesPanel.SetActive (false);
		//At start, menu is on the first page
		menuSwitch = false;

	}

	// Update is called once per frame
	void Update () {

		//Getting current lives from Player controller component/script and displaying that number + 
		//as a string in the pause menu
		pauseLives.text = "0" + GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().playerLifes.ToString ();


		//Game can be paused or un-paused by pressing 'p' 
		//(Or 'Enter'[PC] / 'Return'[Mac], which is more intuitive to those who emulated the original)
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Return)) {

			paused = !paused;
			//Pause sound plays
			pauseSound.Play();
			//Debug info for developers
			print ("Pause/Play");

		}
		//if not paused then pause
		if (paused) {

			//Set Game time to 0 (or 'frozen')
			Time.timeScale = 0f;
			pauseMenuUI.SetActive (true);
			//Dsiplay the pause menu
			//Player can switch between pages of the pause menu with the 'space' key
			if (Input.GetKeyDown (KeyCode.Space)) {

				menuSwitch = !menuSwitch;
				//Play next page sound
				nextSound.Play(); 

			}

			//Switch to Lives page if on inventory page...
			if (menuSwitch) {

				inventoryPanel1.SetActive (false);
				livesPanel.SetActive (true);

				//..or to inventory page if on lives page
			} else if (!menuSwitch) {

				inventoryPanel1.SetActive (true);
				livesPanel.SetActive (false);

			}



			//if paused then un-pause
		} else if (!paused) {

			//Set Game time to 1 (or normal speed)
			Time.timeScale = 1f;
			pauseMenuUI.SetActive (false);
			//Hide the pause menu

		}

	}


}