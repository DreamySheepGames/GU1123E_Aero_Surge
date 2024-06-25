using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpaceNoDestroy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;            // enemy will move down after an amount of time
    [SerializeField] protected bool isMoveDown = true;

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        // Enemy will stay still for an amount of time before moving down
        if (isMoveDown)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
