using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    protected override void Start()
    {
        base.Start();
        moveSpeed = 2f;
        //transform.Rotate(0, 0, 90);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
