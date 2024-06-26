using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimsController : MonoBehaviour
{
    enum AnimationState {idle, tiltLeft, tiltRight}
    AnimationState curState;
    Animator animator;
    CircleCollider2D collider;                          // turn on the collider after done reiving because it's turned of when the player is dead

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        curState = AnimationState.idle;
        UpdateAnimation();   
    }

    private void Update()
    {
        // Read input to trigger animation
        if (Input.GetKey(KeyCode.LeftArrow))
            ChangeState(AnimationState.tiltLeft);
        else if (Input.GetKey(KeyCode.RightArrow))
            ChangeState(AnimationState.tiltRight);
        else
            ChangeState(AnimationState.idle);
    }

    void ChangeState(AnimationState newState)
    {
        if (newState != curState)
        {
            curState = newState;
            UpdateAnimation();
        }
    }

    void UpdateAnimation()
    {
        foreach (AnimationState state in System.Enum.GetValues(typeof(AnimationState)))
        {
            animator.ResetTrigger(state.ToString());
        }

        // Set the new state
        animator.SetTrigger(curState.ToString());
    }

    public void SetAnimToIdle()
    {
        collider.enabled = true;

        foreach (AnimationState state in System.Enum.GetValues(typeof(AnimationState)))
        {
            animator.ResetTrigger(state.ToString());
        }

        animator.SetTrigger("doneRevive");
    }
}
