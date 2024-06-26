using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{
    Vector2 moveDir;
    public float moveSpeed = 10f;

    private void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    // Target Bullet Controller uses this
    public void SetMoveDir(Vector2 moveDir_)
    {
        moveDir = moveDir_;
    }
}
