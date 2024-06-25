using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : MonoBehaviour
{
    [SerializeField] bool canSpawn = true;
    [SerializeField] float spawnRate = 0.3f;
    [SerializeField] GameObject[] EnemyPrefabs;

    public float timeStartSpawning = 70f;
    public float timeEndSpawning = 95f;

    private void Start()
    {
        StartCoroutine(SpawnerRandomWave(0));
        StartCoroutine(TurnOffSpawner());       // canSpawn = false
    }

    private IEnumerator SpawnerRandomWave(int enemy)
    {
        WaitForSeconds wait = new WaitForSeconds(timeStartSpawning);
        yield return wait;

        // set spawn rate
        wait = new WaitForSeconds(spawnRate);

        // Spawn the first enemy then wait
        GameObject ship = Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);

        yield return wait;

        while (canSpawn)
        {
            // set random x pos
            Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), transform.position.y);

            Instantiate(EnemyPrefabs[enemy], spawnPos, Quaternion.identity);

            yield return wait;
        }
    }

    private IEnumerator TurnOffSpawner()
    {
        WaitForSeconds endTime = new WaitForSeconds(timeEndSpawning);

        yield return endTime;
        canSpawn = false;
    }
}
