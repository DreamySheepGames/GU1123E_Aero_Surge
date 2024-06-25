using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9 : Enemy
{
    float timeBeforeStayStill = 2f;       // Enemy will move down for 0.5s
    float timeBeforeContinueMoving = 3f;    // Enemy stays still for 0.5s then continue to move down
    private void Start()
    {
        base.Start();
        isMoveDown = true;
        StartCoroutine(WaitBeforeStayStill());
    }

    private IEnumerator WaitBeforeStayStill()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBeforeStayStill);
        yield return wait;
        isMoveDown = false;
    }
}
