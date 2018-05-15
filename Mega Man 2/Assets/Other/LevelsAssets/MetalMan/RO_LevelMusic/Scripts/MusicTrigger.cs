//Name Robert O'Mara
//Date 03-21-18
//purpose: To play the music for the game and once triggered cannot be triggered again




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour {

	public bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Robert If the player enters the area play music and trigger. Once the trigger is true dont play again.
	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {
			if (triggered == false) {
				PlayMusic ();
				triggered = true;
			}
			else if(triggered == true) {
				//Debug.Log ("Music was already triggered");
			}
		} 
	}
	void PlayMusic(){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}
