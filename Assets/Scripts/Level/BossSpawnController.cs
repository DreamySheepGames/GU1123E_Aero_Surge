using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnController : MonoBehaviour
{
    [SerializeField] float timeStartSpawning = 125f;
    public GameObject boss;
    public GameObject bossHealthBar;

    private void Start()
    {
        boss.SetActive(false);
        bossHealthBar.SetActive(false);
        StartCoroutine(SpawnerBoss());

    }

    private IEnumerator SpawnerBoss()
    {
        yield return new WaitForSeconds(timeStartSpawning);

        // Spawn enemy
        boss.SetActive(true);
        bossHealthBar.SetActive(true);
    }
}
