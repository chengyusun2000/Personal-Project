using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : StateMachineBehaviour
{
    public float CurrentDistance;
    private Transform PlayerTransform;
    private float AttackDistance=0.6f;
    private float TrackingDistance = 100f;
    private float Speed =1.4f;
    private MonsterScale monsterScale;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        monsterScale = animator.transform.GetComponent<MonsterScale>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentDistance = Vector3.Distance(animator.transform.position, PlayerTransform.position);
        if (CurrentDistance<AttackDistance)
        {
            animator.SetBool("StartAttack", true);
        }
        else if(CurrentDistance>AttackDistance&&CurrentDistance<TrackingDistance)
        {
            if(animator.transform.position.x-PlayerTransform.position.x>0)
            {
                animator.transform.localScale =new Vector3(monsterScale.vector.x*-1, monsterScale.vector.y, monsterScale.vector.z);
            }
            else
            {
                animator.transform.localScale = monsterScale.vector;
            }
            animator.transform.position= Vector3.MoveTowards(animator.transform.position, PlayerTransform.position, Speed * Time.deltaTime);
        }
    }

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
