using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour {

	/*Name: Robert O'Mara
	* Date: 03/14/18
	* Credit: Reference Unity API on destroy https://docs.unity3d.com/ScriptReference/Object.Destroy.html
	* purpose: To give the player an additonal life when picked up. Timer set to destory the object after a 10 second timer 
	*/

	public int megamanEnergy;
	private int destroyTime = 10;
	private float delayTime = .15f;
	public int energyToAdd = 25;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		megamanEnergy = GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().energy;
		DestoryTimer ();
	}

	void OnCollisionEnter2D(Collision2D energy)
	{
		if (energy.gameObject.tag == "Player") {
			PlaySound ();
			GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().energy = GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().energy + energyToAdd;
			Destroy (gameObject, delayTime);
		}
	}
	void DestoryTimer()
	{
		Destroy (gameObject, destroyTime);
	}
	void PlaySound()
	{
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}
