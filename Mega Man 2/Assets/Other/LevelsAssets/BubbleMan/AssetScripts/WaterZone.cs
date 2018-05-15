using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  /*        
  //        Developer Name: Domenic Dehelean
  //        Contribution:   Created Script
  //        Function:       Zone for Bubble Man level where Megaman is under water which increases jump height.
  //        Date:           April 16, 2018
  //
  */


public class WaterZone : MonoBehaviour
{
    //Get Megaman Object
    GameObject MM;

    //Jump script from Megaman
    Jump J;
    //Get base value for Megaman's jump
    float JB;
    //modifier for Megaman's jump
    public float JumpMod;
    //float for changed jump variable
    float JumpChanged;

    private void Start()
    {
        MM = GameObject.FindGameObjectWithTag("Player");
        //Get MM's Jump script
        J = MM.GetComponent<Jump>();
        //Set base jump value
        JB = J.jumpVelocity;
        //Give Jump modifier a value if value is missing
        if (JumpMod == 0)
        {
            JumpMod = 2;
        }
        //Set the baseline of a modified jump
        JumpChanged = JB + JumpMod;
        //Set color of water block to be more watery
        GetComponent<Renderer>().material.color = Color.blue;
    }

    //Changes jump volume on entering water zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            J.jumpVelocity = JumpChanged;
        }
    }

    //Changes jump volume back to basic when leaving water zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            J.jumpVelocity = JB;
        }
    }

}
