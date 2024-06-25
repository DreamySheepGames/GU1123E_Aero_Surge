using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{
    Vector2 moveDir;
    public float moveSpeed = 10f;

    private void OnEnable()
    {
        Invoke("DisableBullet", 3f);      // set active to fasle after 3s
    }

    private void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    // Target Bullet Controller uses this
    public void SetMoveDir(Vector2 moveDir_)
    {
        moveDir = moveDir_;
    }
    
    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }

    // avoid possible issues with ivocation method when object isn't active
    private void OnDisable()
    {
        CancelInvoke();
    }
}
