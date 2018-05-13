using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI_RandomRightJumpBehavior : StateMachineBehaviour {

    /*        
   //        Developer Name: Travis Imhoff
   //         Contribution: Created Script
   //                A state machine that will randomize between the right short, medium, and high jumps when attacked.
   //                March 16, 2018
   //                References: https://www.youtube.com/watch?v=_Mv6tFKbKvI
   //*/



    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("randRightJump", Random.Range(0, 3));
	}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
	//
	//}
}
