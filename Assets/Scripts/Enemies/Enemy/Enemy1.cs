using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    float timeBeforeStayStill = 0.5f;       // Enemy will move down for 0.5s
    float timeBeforeContinueMoving = 1f;    // Enemy stays still for 0.5s then continue to move down

    protected override void Start()
    {
        base.Start();
        isMoveDown = true;
        moveSpeed = 6f;
        StartCoroutine(WaitBeforeStayStill());
        StartCoroutine(WaitBeforeContinueMoving());
    }

    private IEnumerator WaitBeforeStayStill()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBeforeStayStill);
        yield return wait;
        isMoveDown = false;
    }

    private IEnumerator WaitBeforeContinueMoving()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBeforeContinueMoving);
        yield return wait;
        moveSpeed = 2f;
        isMoveDown = true;
    }
}
