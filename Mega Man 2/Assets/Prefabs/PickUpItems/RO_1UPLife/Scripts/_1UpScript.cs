using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Name: Robert O'Mara
 * Date: 03/14/18
 * Credit: Reference Unity API on destroy https://docs.unity3d.com/ScriptReference/Object.Destroy.html
 * purpose: To give the player an additonal life when picked up. Timer set to destory the object after a 10 second timer 
  */


public class _1UpScript : MonoBehaviour {
	
	public int MegamanLives;
	private int destoryTime = 10;
	private float delayTime = .15f;



//	 Use this for initialization
	void Start () {
		MegamanLives = GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().playerLifes;
	}
	
	// Update is called once per frame
	void Update () {
		DestoryTimer ();
		
	}

	void OnCollisionEnter2D(Collision2D lifeup)
	{
		if (lifeup.gameObject.tag == "Player") {
			PlaySound();
			MegamanLives = GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().playerLifes ++;
			Destroy (gameObject,delayTime);
		}
	}
	void DestoryTimer()
	{
		Destroy (gameObject, destoryTime);
	}
	void PlaySound()
	{
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}
