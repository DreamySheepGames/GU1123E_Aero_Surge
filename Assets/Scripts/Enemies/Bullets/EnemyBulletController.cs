using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    // this script is for bullet pooling by disable the bullets after 3 second of being active
    private float timeBeforeDeactivate = 5f;

    private void OnEnable()
    {
        Invoke("DisableBullet", timeBeforeDeactivate);      // set active to fasle after 3s
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
