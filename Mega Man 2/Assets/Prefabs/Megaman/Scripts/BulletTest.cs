using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.name == "MegaManV3")
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(3);
        
        // Destroy(gameObject);
    }
}
