using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : Enemy
{
    float timeBeforeStayStill = 2f;       // Enemy will move down for 0.5s
    protected override void Start()
    {
        base.Start();
        isMoveDown = true;
        moveSpeed = 2f;
        StartCoroutine(WaitBeforeStayStill());
    }

    private IEnumerator WaitBeforeStayStill()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBeforeStayStill);
        yield return wait;
        isMoveDown = false;
    }
}
