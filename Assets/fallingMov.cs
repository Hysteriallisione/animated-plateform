using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingMov : StateMachineBehaviour
{
    public Rigidbody2D rigibrody;
    public float gravScalFall;
    public Animator animateur;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (rigibrody.velocity.y > 1)
        {
            rigibrody.gravityScale = gravScalFall;
            animateur.SetBool("falling", true);
        }
        else
        {
            rigibrody.gravityScale = 1;
        }
    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
