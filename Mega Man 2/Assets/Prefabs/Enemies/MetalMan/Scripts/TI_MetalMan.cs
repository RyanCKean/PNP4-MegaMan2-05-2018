using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_MetalMan : MonoBehaviour {

    /*        
    //        Developer Name: Travis Imhoff
    //         Contribution: Created Script
    //                Metal Man will jump when Mega Man shoots his weapon
    //                March 16, 2018
    //*/

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.K))
        {
            anim.SetBool("isAttacked", true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            anim.SetBool("isAttacked", false);
        }
	}

}
