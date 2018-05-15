using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Robert O'Mara
//Date 03/14/18
//purpose: To allow the player to move up and down ladders sends a signal to the player controller 
//to allow movement up and down while on the trigger

public class Ladder : MonoBehaviour {

	public GameObject player;
	public bool LadderOn = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//LadderCheck ();
		
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			//Debug.Log ("ontheladder");
			LadderOn = true;
            player.GetComponent<PlayerController> ().onLadder = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
		}


	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			//Debug.Log ("off the ladder");
			LadderOn = false;
			player.GetComponent<PlayerController> ().onLadder = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;

        }
	}
	void LadderCheck (){
//		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 3.0f;
		if (LadderOn = true && Input.GetKeyDown(KeyCode.W)){
			//Debug.Log ("plz plz");
			//player.GetComponent<Transform> ().Translate (Vector3.up * Time.deltaTime, Space.World);
		}
	}

}
