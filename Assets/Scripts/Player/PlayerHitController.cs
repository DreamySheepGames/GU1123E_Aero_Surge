using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    public bool isPlayerInvincible = false;
    public GameObject reloadBtn;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayerInvincible && !animator.GetBool("dead") && !animator.GetBool("revive"))
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy Bullet"))
            {
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
