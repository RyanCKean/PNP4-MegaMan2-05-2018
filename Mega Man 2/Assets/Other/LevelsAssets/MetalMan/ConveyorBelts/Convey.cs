using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convey : MonoBehaviour {

    public GameObject trig;

    void Awake()
    {
        trig.SetActive(true);   
    }


    void OnTriggerStay2D(Collider2D tri)
    {
        if(tri.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            trig.SetActive(false);
        } 
    }

    void OnTriggerEnter2D(Collider2D tris)
    {
        trig.SetActive(true);
    }


    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
