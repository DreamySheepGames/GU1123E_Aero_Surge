using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    public bool isPlayerInvincible = false;
    public GameObject reloadBtn;
    Animator animator;
    CircleCollider2D collider;                  // turn of the collider, if not then the explode anim will reapeat it will when there are multiple bullets
                                                // we will turn on the collider in PlayerAnimsController at the end of reviving animation

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy Bullet"))
        {
            if (!isPlayerInvincible && !animator.GetBool("dead") && !animator.GetBool("revive"))
            {
                collider.enabled = false;
                animator.SetTrigger("dead");
                //Destroy(gameObject);
            }
        }
        
    }

    public void PlayerSelfDestroy()
    {
        // take 1 lives counter
        GameManager.livesCounter--;

        if (GameManager.livesCounter <= 0)
        {
            reloadBtn.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            // revive animation
            animator.SetTrigger("revive");
        }
    }
}
