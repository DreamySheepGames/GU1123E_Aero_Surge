using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpace : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;            // enemy will move down after an amount of time
    [SerializeField] protected bool isMoveDown = true;
    public float health = 10f;
    protected Animator animator;                                // explode animation when health reaches 0

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        // Play enemy explode animation
        if (health <= 0)
        {
            animator.SetBool("Dead", true);
        }

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

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Bullet"))
        {
            health -= 1;
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
