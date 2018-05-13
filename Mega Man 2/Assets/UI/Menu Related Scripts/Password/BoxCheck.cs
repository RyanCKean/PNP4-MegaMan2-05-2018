using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name - Kaitlin Soter
 * 1/17/2018
 * Credit: Project & Portfolio 4 - Mega Man 2 group project
 * Purpose: used alongside passwordscript and returns the bool for seeing if a box is checked/usable
 */

public class BoxCheck : MonoBehaviour {


    public bool boxChecked = false;

    public bool GetBoxChecked()
    {
        return boxChecked;
    }

    public void SetBoxChecked(bool value)
    {
        boxChecked = value;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
