using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Enemy
{
    [Header("Boss Settings")]
    [SerializeField] float timeBeforeStayStill = 1f;        // Enemy will move down for 0.5s
    public static bool IsAlive = true;                      // Work with junk spawner (boss1)

    [Header("UI")]
    public BossHealthBar bossHealthBar;
    public GameObject mainMenuBtn;
    public GameObject winTxt;

    [Header("Player")]                                      // turn player invincible on when boss is defeated
    public GameObject player;

    protected override void Start()
    {
        base.Start();
        Health = 200f;
        moveSpeed = 5f;

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
            player.GetComponent<PlayerHitController>().isPlayerInvincible = true;
            mainMenuBtn.SetActive(true);
            IsAlive = false;
        }
    }

    void UpdateHealthBar()
    {
        bossHealthBar.SetHealth(Health);
    }

    public void EnableWinText()
    {
        winTxt.SetActive(true);
    }
}
