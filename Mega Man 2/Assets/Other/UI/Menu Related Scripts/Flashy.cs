using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name - Kaitlin Soter
 * 1/17/2018
 * Credit: Project & Portfolio 4 - Mega Man 2 group project
 * Purpose: Makes gameobject flash
 */

public class Flashy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("TileSelect", 0f, 0.14f);
    }

    void TileSelect()
    {
        if (this.GetComponent<MeshRenderer>().enabled == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (this.GetComponent<MeshRenderer>().enabled == false)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
