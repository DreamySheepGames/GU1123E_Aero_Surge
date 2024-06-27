using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimsController : MonoBehaviour
{
    enum AnimationState {idle, tiltLeft, tiltRight}
    AnimationState curState;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //collider = GetComponent<CircleCollider2D>();
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

    public void SetAnimToDoneRevive()
    {
        // turn on the collider after done reiving because it's turned of when the player is dead
        GetComponent<CircleCollider2D>().enabled = true;

        foreach (AnimationState state in System.Enum.GetValues(typeof(AnimationState)))
        {
            animator.ResetTrigger(state.ToString());
        }

        // There's a bug that set the animation from revive to idle BEFORE the collider is enabled that makes player invincible
        // This function is called at the last frame of the revive animation, but sometimes the idle is triggered while the revive anim hasn't finished.
        // Which caused the bug.
        // Solved by creating a 1-frame animation called "Done Revive" which will call the SetAnimToIdle() func below
        // The revive animation will use this func to call the "Done Revive" animation
        // the collider will be enable at the FIRST frame of that "Done Revive" anim, unlike "Revive" which enable at the LAST frame.
        // In conclusion: "Revive" anim tries to enable the collider -> "Done Revive" anim enables it for sure -> Idle anim
        if (GetComponent<CircleCollider2D>().enabled)
            animator.SetTrigger("doneRevive");
    }

    public void SetAnimToIdle()
    {
        // turn on the collider after done reiving because it's turned of when the player is dead
        GetComponent<CircleCollider2D>().enabled = true;

        foreach (AnimationState state in System.Enum.GetValues(typeof(AnimationState)))
        {
            animator.ResetTrigger(state.ToString());
        }

        if (GetComponent<CircleCollider2D>().enabled)
            animator.SetTrigger("idle");
    }
}
