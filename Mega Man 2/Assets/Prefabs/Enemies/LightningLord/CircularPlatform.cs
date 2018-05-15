using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatform : MonoBehaviour
{
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius = 3f, angularSpeed = 1f;
    float posX, posY, angle = 0f;
    public bool touchingPlayer;

	// Use this for initialization
	void Start ()
    {
        touchingPlayer = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0f;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            touchingPlayer = true;
            col.collider.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag =="Player")
        {
            touchingPlayer = false;
            col.collider.transform.SetParent(null);
        }
    }

}
