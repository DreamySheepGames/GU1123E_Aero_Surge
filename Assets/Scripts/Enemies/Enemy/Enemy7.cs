using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7 : Enemy
{
    protected override void Start()
    {
        base.Start();
        isMoveDown = true;
        moveSpeed = 6f;
    }
}
