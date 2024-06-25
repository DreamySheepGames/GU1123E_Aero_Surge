using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2EnemiesSpawner : MonoBehaviour
{
    [Header("PREFABS")]
    [SerializeField] GameObject[] EnemyPrefabs;

    [Header("FIRST WAVE SETTINGS")]
    [SerializeField] bool canSpawn = true;
    [SerializeField] float spawnRate = 3.5f;
    [SerializeField] int amountToSpawn = 5;

    [Header("SECOND WAVE SETTINGS")]
    [SerializeField] bool canSpawn2 = true;
    [SerializeField] float spawnRate2 = 3f;
    [SerializeField] float secondWaveStartAt = 30f;

    [Header("THIRD WAVE SETTINGS")]
    [SerializeField] bool canSpawn3 = true;
    [SerializeField] float spawnRate3 = 3f;
    [SerializeField] float thirdWaveStartAt = 40f;

    [Header("METEOR WAVE SETTINGS")]
    [SerializeField] bool canSpawnMeteor = true;
    [SerializeField] float spawnRateMeteor = 0.1f;
    [SerializeField] float meteorStartAt = 89f;
    [SerializeField] float meteorEndAt = 94f;
    public float randDistance = 10f;


    private void Start()
    {
        StartCoroutine(SpawnerFirstWave(EnemyPrefabs));
        StartCoroutine(SpawnerSecondWave(EnemyPrefabs));
        StartCoroutine(SpawnerThirdWave(EnemyPrefabs));

        // METEOR WAVE
        StartCoroutine(SpawnerMeteorWave(EnemyPrefabs));
        StartCoroutine(StopSpawnMeteor());
    }

    private IEnumerator SpawnerFirstWave(GameObject[] EnemyPrefabs_)
    {
        // set spawn rate
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        int spawnStep = 1;

        // set spawn location
        Vector2 spawnPointLeft = new Vector2(transform.position.x - 5f, transform.position.y);
        Vector2 spawnPointRight = new Vector2(transform.position.x + 5f, transform.position.y);

        float randDistance = 2f;

        // Wait for a while then spawn
        while (canSpawn)
        {
            yield return wait;
            switch (spawnStep)
            {
                case 1:
                    for (int i = 0; i < amountToSpawn; i++)
                    {
                        Vector2 spawnPoint = new Vector2(Random.Range(spawnPointLeft.x - randDistance, spawnPointLeft.x + randDistance), Random.Range(transform.position.y + randDistance, transform.position.y - randDistance));
                        Instantiate(EnemyPrefabs[0], spawnPoint, Quaternion.identity);
                    }
                    break;

                case 2:
                    for (int i = 0; i < amountToSpawn; i++)
                    {
                        Vector2 spawnPoint = new Vector2(Random.Range(spawnPointRight.x - randDistance, spawnPointRight.x + randDistance), Random.Range(transform.position.y + randDistance, transform.position.y - randDistance));
                        Instantiate(EnemyPrefabs[0], spawnPoint, Quaternion.identity);
                    }
                    break;

                case 3:
                    for (int i = 0; i < amountToSpawn; i++)
                    {
                        Vector2 spawnPoint = new Vector2(Random.Range(transform.position.x - randDistance, transform.position.x + randDistance), Random.Range(transform.position.y + randDistance, transform.position.y - randDistance));
                        Instantiate(EnemyPrefabs[0], spawnPoint, Quaternion.identity);
                    }
                    break;
            }

            spawnStep++;
            if (spawnStep == 4)
            {
                canSpawn = false;
            }
        }
    }

    private IEnumerator SpawnerSecondWave(GameObject[] EnemyPrefabs_)
    {
        yield return new WaitForSeconds(secondWaveStartAt);

        // set spawn rate
        WaitForSeconds wait = new WaitForSeconds(spawnRate2);
        int spawnStep = 1;

        // set spawn location
        Vector2 spawnPointLeft = new Vector2(transform.position.x - 5f, transform.position.y);
        Vector2 spawnPointRight = new Vector2(transform.position.x + 5f, transform.position.y);

        float randDistance = 2f;

        // Wait for a while then spawn
        while (canSpawn2)
        {
            yield return wait;
            switch (spawnStep)
            {
                case 1:
                    for (int i = 0; i < amountToSpawn; i++)
                    {
                        Vector2 spawnPoint = new Vector2(Random.Range(spawnPointLeft.x - randDistance, spawnPointLeft.x + randDistance), Random.Range(transform.position.y + randDistance, transform.position.y - randDistance));
                        Instantiate(EnemyPrefabs[1], spawnPoint, Quaternion.identity);
                    }
                    break;

                case 2:
                    for (int i = 0; i < amountToSpawn; i++)
                    {
                        Vector2 spawnPoint = new Vector2(Random.Range(spawnPointRight.x - randDistance, spawnPointRight.x + randDistance), Random.Range(transform.position.y + randDistance, transform.position.y - randDistance));
                        Instantiate(EnemyPrefabs[1], spawnPoint, Quaternion.identity);
                    }
                    break;

                case 3:
                    for (int i = 0; i < amountToSpawn; i++)
                    {
                        Vector2 spawnPoint = new Vector2(Random.Range(transform.position.x - randDistance, transform.position.x + randDistance), Random.Range(transform.position.y + randDistance, transform.position.y - randDistance));
                        Instantiate(EnemyPrefabs[1], spawnPoint, Quaternion.identity);
                    }
                    break;
            }

            spawnStep++;
            if (spawnStep == 4)
            {
                canSpawn2 = false;
            }
        }
    }

    private IEnumerator SpawnerThirdWave(GameObject[] EnemyPrefabs_)
    {
        yield return new WaitForSeconds(thirdWaveStartAt);

        // set spawn rate
        WaitForSeconds wait = new WaitForSeconds(spawnRate3);
        int spawnStep = 1;

        // set spawn location
        Vector2 spawnPointLeft = new Vector2(transform.position.x - 5f, transform.position.y);
        Vector2 spawnPointRight = new Vector2(transform.position.x + 5f, transform.position.y);

        // Wait for a while then spawn
        while (canSpawn3)
        {
            yield return wait;
            switch (spawnStep)
            {
                case 1:
                    Vector2 spawnPoint = new Vector2(spawnPointLeft.x, transform.position.y);
                    Instantiate(EnemyPrefabs[2], spawnPoint, Quaternion.identity);
                    break;

                case 2:
                    spawnPoint = new Vector2(spawnPointRight.x, transform.position.y);
                    Instantiate(EnemyPrefabs[2], spawnPoint, Quaternion.identity);
                    break;

                case 3:
                    spawnPoint = new Vector2(spawnPointLeft.x / 2, transform.position.y);
                    Instantiate(EnemyPrefabs[2], spawnPoint, Quaternion.identity);
                    break;

                case 4:
                    spawnPoint = new Vector2(spawnPointRight.x / 2, transform.position.y);
                    Instantiate(EnemyPrefabs[2], spawnPoint, Quaternion.identity);
                    break;
            }

            spawnStep++;
            if (spawnStep == 5)
            {
                canSpawn3 = false;
            }
        }
    }


    // METEOR WAVE
    IEnumerator SpawnerMeteorWave(GameObject[] EnemyPrefabs_)
    {
        yield return new WaitForSeconds(meteorStartAt);

        while (canSpawnMeteor)
        {
            yield return new WaitForSeconds(spawnRateMeteor);
            Vector2 spawnPoint = new Vector2(Random.RandomRange(transform.position.x - randDistance, transform.position.x + randDistance), transform.position.y);
            GameObject meteor = Instantiate(EnemyPrefabs_[3], spawnPoint, Quaternion.identity);
        }
    }

    IEnumerator StopSpawnMeteor()
    {
        yield return new WaitForSeconds(meteorEndAt);
        canSpawnMeteor = false;
    }
}
