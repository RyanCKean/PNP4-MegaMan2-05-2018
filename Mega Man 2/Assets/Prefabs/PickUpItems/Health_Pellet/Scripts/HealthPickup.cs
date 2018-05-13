using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Name: Robert McGloin
//Date: 4/19/2018

public class HealthPickup : MonoBehaviour {

	private int destroyTime = 10;
	private float delayTime = .15f;


	// Use this for initialization
	void Start () {
		
	}




	// Update is called once per frame
	void Update () {
		DestroyTimer ();
		
	}

	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.name == "MegaManV3") {
			
			PlaySound ();
			//collision.gameObject.GetComponent<PlayerController>().HealDamage(10);
			Destroy (gameObject, delayTime);
		}
	}

	void DestroyTimer(){

		Destroy (gameObject, destroyTime);
	}

	void PlaySound(){

		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}