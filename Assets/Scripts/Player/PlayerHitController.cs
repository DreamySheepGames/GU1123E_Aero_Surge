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
        if (!isPlayerInvincible)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy Bullet"))
            {
                animator.SetBool("Dead", true);
                //Destroy(gameObject);
            }
        }
        
    }

    public void PlayerSelfDestroy()
    {
        reloadBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
