using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  /*        
  //        Developer Name: Domenic Dehelean
  //        Contribution:   Created Script
  //        Function:       Platform for Megaman to jump on that will drop as soon as Megaman lands on it.
  //        Date:           April 16, 2018
  //
  */


public class FallingPlatform : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Makes platform fall when Megaman lands on it
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //Freezes constraints that shouldn't change
            Refreeze();
        }
    }

    void Refreeze()
    {
        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
