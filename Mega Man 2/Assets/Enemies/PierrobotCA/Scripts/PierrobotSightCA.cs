using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierrobotSightCA : MonoBehaviour {

    public Transform viewStart, viewEnd;
    private bool solidCollision = false;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        solidCollision = Physics2D.Linecast(viewStart.position, viewEnd.position, 1 << LayerMask.NameToLayer("Solid"));
        Debug.DrawLine(viewStart.position, viewEnd.position, Color.blue);

    }


    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player")
            {
                if (transform.localScale.x == 1)
                {
                    this.transform.localScale = new Vector2(-1, 1);

                }
                else if (transform.localScale.x == -1)
                {
                    this.transform.localScale = new Vector2(1, 1);
                }
            }
        }
    }
