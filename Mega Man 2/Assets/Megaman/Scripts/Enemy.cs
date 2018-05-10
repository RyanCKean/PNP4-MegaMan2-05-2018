using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Name: Lyndon Jones
 *Date: 1/17/18
 *Credit: Project & Portfolio 4 - MegaMan 2 group project
 *Purpose: Test Projectile Damage                                   */
public class Enemy : MonoBehaviour {

    public int health = 10;


	public void Damage(int dmg) {
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
    }


    
}
