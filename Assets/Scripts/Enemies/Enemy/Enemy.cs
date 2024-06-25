using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] protected float moveSpeed = 2f;            // enemy will move down after an amount of time
    [SerializeField] protected bool isMoveDown = false;
    [SerializeField] protected float health = 9f;
    protected Animator animator;                                // explode animation when health reaches 0

    public float Health
    {
        get { return health; }
        protected set { health = value; }
    }

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
