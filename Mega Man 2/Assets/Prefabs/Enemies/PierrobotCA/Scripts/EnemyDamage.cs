using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for applying damage by enemies to the player
//Christian Ashlock

public class EnemyDamage : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D enemyCollision)
    {
        if (enemyCollision.gameObject.name == "MegaManV3")
            enemyCollision.gameObject.GetComponent<PlayerController>().TakeDamage(3);
           
    }
}
