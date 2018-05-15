using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Name: Robert O'Mara
//Date: 3/15/18
//Credit: www.docs.unity3d.com/ScriptReference/Vector2.html
//Purpose: To rewrite gravity to make mega man jump more like the original

public class JumpGravity : MonoBehaviour {
	public float gravity = 2.5f;
	public float lowgravity = 2f;
	Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Robert - this takes the rigidbody and changes the fall gravity based off of 2 fall speeds. The two speeds 
		//will be for if the player holds the jump button down (fallMultiplier) and the other(lowJumpmultiplier) will be for 
		//if the player taps the space bar to create a smaller jump
		//Debug:Added the -1 to account for the 1 gravity at start
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (gravity - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetKey (KeyCode.Space)) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowgravity - 1) * Time.deltaTime;
		}
		
	}
}
