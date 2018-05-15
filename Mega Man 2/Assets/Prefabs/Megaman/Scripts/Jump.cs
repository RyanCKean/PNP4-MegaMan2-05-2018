using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Name: Robert O'Mara
//Date: 3/15/18
//Credit: www.docs.unity3d.com/ScriptReference/Vector2.html
//Purpose: To rewrite gravity to make mega man jump more like the original

public class Jump : MonoBehaviour {


	public float jumpVelocity;
	public bool grounded;


	void Start(){
	}

	// Update is called once per frame
	void Update () {
		grounded = GetComponent<PlayerController> ().isGrounded;
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded == true) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpVelocity;
			}
		}
	}
}
