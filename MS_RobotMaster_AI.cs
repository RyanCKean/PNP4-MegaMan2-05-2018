using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS_RobotMaster_AI : MonoBehaviour {

    //*
    //    Devloper Name: Malik Smith
    //    Contribution: Created Script
    //    Robot Masters will have a health bar and damage calculation along with shooting properly
    //    May 13, 2018
    //*/

    public int health = 10;
	
	public void Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
    }

    public Direction bulletDirection = Direction.RIGHT;
    public float speed = 5.0f;
    public int damage = 5;

    private Transform _transform;

        void Start() {
        _transform = transform;
    }
    // Update is called once per frame
    void Update() {
        MoveBullet();
    }

    void MoveBullet()
    {
        int moveDirection = bulletDirection == Direction.LEFT ? -1 : 1;

        float translate = moveDirection * speed * Time.deltaTime;
        _transform.Translate(translate, 0, 0);
    }

    void OncollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            collision.collider.gameObject.GetComponent<Enemy>().Damage(damage);
        }
    }
}
