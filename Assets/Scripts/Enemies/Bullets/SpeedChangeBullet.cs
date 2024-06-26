using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedRate = 1f;                // original speed * speed rate
    public float timeUntilChange = 1f;          // bullet speed will change after second

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("ChangeSpeed", timeUntilChange);
    }

    void ChangeSpeed()
    {
        rb.velocity *= speedRate;
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
