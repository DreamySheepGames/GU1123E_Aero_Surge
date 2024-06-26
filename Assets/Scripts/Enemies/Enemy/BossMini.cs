using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMini : Enemy
{
    [SerializeField] float timeBeforeStayStill = 1f;        // Enemy will move down for 0.5s
    public BossHealthBar bossHealthBar;

    protected override void Start()
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
