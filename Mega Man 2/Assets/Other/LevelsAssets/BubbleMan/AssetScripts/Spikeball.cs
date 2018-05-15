using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  /*        
  //        Developer Name: Domenic Dehelean
  //        Contribution:   Created Script
  //        Function:       Level hazard for Megaman to avoid. On contact, spike ball object will kill Megaman.
  //        Date:           April 16, 2018
  //
  */


public class Spikeball : MonoBehaviour
{
    //Get PlayerController script from Megaman
    PlayerController MM;


    private void Start()
    {
        //Set PlayerController script from Megaman
        MM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            //Make Megaman take damage equal to his remaining health
            MM.TakeDamage(MM.currentHealth);
            Debug.Log("Dead!");
        }
    }
}
