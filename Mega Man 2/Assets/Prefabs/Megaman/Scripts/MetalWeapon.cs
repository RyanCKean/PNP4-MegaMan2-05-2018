using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalWeapon : MonoBehaviour {

    public Direction metalDirection = Direction.RIGHT;
    public float speed = 10f;
    public int damage = 7;

    private Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMetal();

    }

    // Causes the bullet to move at a set speed
    void MoveMetal()
    {
        int moveDirection = metalDirection == Direction.LEFT ? -1 : 1;

        float translate = moveDirection * speed * Time.deltaTime;
        _transform.Translate(translate, 0, 0);

    }

    // Allows bullet to collide with Enemy tag
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.gameObject.GetComponent<EnemyData>().Damage(damage);
            Destroy(gameObject);
        }

    }
}