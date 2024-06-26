using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [Header("Boss Settings")]
    [SerializeField] float timeBeforeStayStill = 1f;        // Enemy will move down for 0.5s
    public static bool IsAlive = true;                      // Work with junk spawner 

    [Header("UI")]
    public BossHealthBar bossHealthBar;
    public GameObject nextLvBtn;

    [Header("Player")]                                      // turn player invincible on when boss is defeated
    public GameObject player;

    protected override void Start()
    {
        base.Start();
        Health = 100f;
        isMoveDown = true;
        moveSpeed = 3.5f;

        bossHealthBar.SetMaxHealth(Health);
        StartCoroutine(WaitBeforeStayStill());
    }

    private IEnumerator WaitBeforeStayStill()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBeforeStayStill);
        yield return wait;
        isMoveDown = false;
    }

    protected override void Update()
    {
        base.Update();

        UpdateHealthBar();

        if (health <= 0)
        {
            // turn on player invincible so player won't get hit by space junk
            player.GetComponent<PlayerHitController>().isPlayerInvincible = true;

            // next level button
            nextLvBtn.SetActive(true);

            // turn of spawn junk space
            IsAlive = false;
        }
    }

    void UpdateHealthBar()
    {
        bossHealthBar.SetHealth(Health);
    }
}
