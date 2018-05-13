using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that controls movement of enemy across the platform
//Christian Ashlock

public class PierrobotMovementCA : MonoBehaviour
{

    public float speed = .5f;
    private Rigidbody2D enemyRigidBody;


    // Use this for initialization
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
}
