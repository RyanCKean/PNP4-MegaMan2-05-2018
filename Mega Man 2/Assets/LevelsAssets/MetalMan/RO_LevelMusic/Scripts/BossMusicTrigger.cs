//Name Robert O'Mara
//Date 03-21-18
//purpose: To play the music for the game and once triggered cannot be triggered again


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicTrigger : MonoBehaviour {

	public GameObject mainMusic;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {
			AudioSource otherMusic = mainMusic.GetComponent<AudioSource> ();
			otherMusic.Stop ();
			PlayMusic ();
		}
	}
	void PlayMusic(){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}
