using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Enemy
{
    public float moveSpeedAtStart = 5f;
    public Vector2 targetPosition = new Vector2(6, 2);

    bool inPostition = false;

    protected override void Start()
    {
        base.Start();
        moveSpeed = 0.2f;
        //transform.Rotate(0, 0, 90);
    }

    protected override void Update()
    {
        base.Update();

        if (inPostition)
            Move();
        else
            MoveToTarget();
    }
    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeedAtStart * Time.deltaTime);
        if ((Vector2)transform.position == targetPosition)
        {
            inPostition = true;
        }
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
