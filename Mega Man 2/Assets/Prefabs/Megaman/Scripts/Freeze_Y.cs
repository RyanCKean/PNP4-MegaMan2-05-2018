using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_Y : MonoBehaviour {

    public bool IsActive;
    public float yPosition;
	// Use this for initialization
	void Start ()
    {
        IsActive = true;
        yPosition = transform.position.y;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsActive)
        {
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        }
		
	}
}
