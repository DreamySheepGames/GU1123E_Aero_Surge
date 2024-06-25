using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRightCorner : MonoBehaviour
{
    [SerializeField] float spawnRate = 8f;
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] int numberToSpawn = 1;

    float timeStartSpawning = 47f;

    private void Start()
    {
        StartCoroutine(SpawnerLeftCorner(0));
    }
    private IEnumerator SpawnerLeftCorner(int enemy)
    {
        // spawner will work after 42 senconds in game
        WaitForSeconds startToSpawn = new WaitForSeconds(timeStartSpawning);
        yield return startToSpawn;

        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        // Spawn the first enemy then wait
        GameObject ship = Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
        ship.transform.rotation = Quaternion.Euler(0, 0, -90);

        yield return wait;

        for (int i = 0; i < numberToSpawn; i++)
        {
            ship = Instantiate(EnemyPrefabs[enemy], transform.position, Quaternion.identity);
            ship.transform.rotation = Quaternion.Euler(0, 0, -90);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
