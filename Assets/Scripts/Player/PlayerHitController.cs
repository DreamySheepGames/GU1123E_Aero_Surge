using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    public static PlayerHitController Instance { get; set; }
    public bool isPlayerInvincible = false;
    public GameObject loseTxt;
    public GameObject reloadBtn;
    Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        isPlayerInvincible = GameManager.isAdventureMode;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Enemy Bullet"))
        {
            if (!isPlayerInvincible)
            {
                GetComponent<CircleCollider2D>().enabled = false;   // turn of the collider, if not then the explode anim will reapeat it will when there are multiple bullets
                                                                    // we will turn on the collider in PlayerAnimsController at the end of reviving animation
                animator.SetTrigger("dead");
            }
        }
        
    }

    public void PlayerSelfDestroy()
    {
        // reset player level
        GameManager.playerLevel = 1;
        GameManager.killCount = 0;

        // take 1 lives counter
        GameManager.livesCounter--;

        if (GameManager.livesCounter <= 0)
        {
            loseTxt.SetActive(true);
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
