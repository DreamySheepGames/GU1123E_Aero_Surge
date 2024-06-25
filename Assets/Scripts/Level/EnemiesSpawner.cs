using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("FIRST WAVE")]
    [SerializeField] bool canSpawn = true;
    [SerializeField] float spawnRate = 3.5f;

    [Header("LAST WAVE")]
    [SerializeField] bool canSpawnLastWave = true;
    [SerializeField] float spawnRateLastWave = 1f;
    [SerializeField] float spawnTimeLastWave = 98f;          // wait until this second in game for the last wave
    [SerializeField] float timeBetweenLastWaves = 0.1f;     // the amount of time between column spawn in the last wave
    [SerializeField] int amountEachColLastWave = 7;         // the amount of enemy in each column in the last wave
    bool doneHalfLastWave = false;
    
    [Header("PREFABS")]
    [SerializeField] GameObject[] EnemyPrefabs;

    private void Start()
    {
        // Spawn the first enemy
        Instantiate(EnemyPrefabs[0], transform.position, Quaternion.identity);

        StartCoroutine(SpawnerFirstWave(0));
        StartCoroutine(SpawnerLastWave(1));
    }

    private IEnumerator SpawnerFirstWave(int enemy)
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        int spawnStep = 2;
        Vector2 spawnPointLeft = new Vector2(transform.position.x - 5f, transform.position.y);
        Vector2 spawnPointRight = new Vector2(transform.position.x + 5f, transform.position.y);


        // Wait for a while then spawn
        while (canSpawn)
        {
            yield return wait;
            switch (spawnStep)
            {
                case 2:
                    float distanceStep = 10f;
                    for (int i = 0; i < spawnStep; i++)
                    {
                        Vector2 spawnPointOrigin = new Vector2(spawnPointLeft.x + distanceStep * i, transform.position.y);
                        Instantiate(EnemyPrefabs[enemy], spawnPointOrigin, Quaternion.identity);
                    }
                    break;

                case 3:
                    Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
                    break;

                case 4:
                    distanceStep = 5f;
                    for (int i = 0; i < spawnStep; i++)
                    {
                        Vector2 spawnPointOrigin = new Vector2(spawnPointLeft.x + distanceStep * i - 2.5f, transform.position.y);
                        Instantiate(EnemyPrefabs[enemy], spawnPointOrigin , Quaternion.identity);
                    }
                    break;

            }

            spawnStep++;
            if (spawnStep == 5)
            {
                canSpawn = false;
            }
        }
    }

    private IEnumerator SpawnerLastWave(int enemy)
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRateLastWave);
        WaitForSeconds waitBetweenCases = new WaitForSeconds(timeBetweenLastWaves);

        yield return new WaitForSeconds(spawnTimeLastWave);

        int spawnStep = 1;

        // set spawn postitions
        Vector2 spawnPointLeft = new Vector2(transform.position.x - 8f, transform.position.y);
        Vector2 spawnPointRight = new Vector2(transform.position.x + 8f, transform.position.y);
        Vector2 spawnPointMidLeft = new Vector2(transform.position.x - 5.4f, transform.position.y);
        Vector2 spawnPointMidRight = new Vector2(transform.position.x + 5.4f, transform.position.y);
        Vector2 spawnPointInLeft = new Vector2(transform.position.x - 2.8f, transform.position.y);
        Vector2 spawnPointInRight = new Vector2(transform.position.x + 2.8f, transform.position.y);

        while (canSpawnLastWave)
        {

            switch (spawnStep)
            {
                // 2 columns
                case 1:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], spawnPointLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointRight, Quaternion.identity);
                    }
                    break;

                // 2 columns
                case 2:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], spawnPointInLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointInRight, Quaternion.identity);
                    }
                    break;

                // 1 column
                case 3:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
                    }
                    break;

                // 2 columns
                case 4:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], spawnPointMidLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointMidRight, Quaternion.identity);
                    }
                    break;

                // 1 column
                case 5:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
                    }
                    break;

                // 3 columns
                case 6:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointRight, Quaternion.identity);
                    }
                    break;

                // 2 columns
                case 7:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], spawnPointMidLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointMidRight, Quaternion.identity);
                    }
                    break;

                // 3 columns
                case 8:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointRight, Quaternion.identity);
                    }
                    break;

                // 4 columns
                case 9:
                    for (int i = 0; i < amountEachColLastWave; i++)
                    {
                        yield return wait;  // spawn rate
                        Instantiate(EnemyPrefabs[enemy], spawnPointLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointRight, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointInLeft, Quaternion.identity);
                        Instantiate(EnemyPrefabs[enemy], spawnPointInRight, Quaternion.identity);
                    }
                    break;
            }

            spawnStep++;

            if (spawnStep == 10)
            {
                if (!doneHalfLastWave)
                {
                    spawnStep = 1;
                    doneHalfLastWave = true;
                }
                else
                {
                    canSpawnLastWave = false;
                }
            }

            //if (spawnStep == 10 && doneHalfLastWave)

            //yield return waitBetweenCases;

        }
    }
}
