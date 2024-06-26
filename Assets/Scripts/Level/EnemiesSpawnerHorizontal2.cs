using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnerHorizontal2 : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] int numberToSpawn = 10;

    float timeStartSpawning = 14;

    private void Start()
    {
        StartCoroutine(SpawnerHorizontal(0));
    }
    private IEnumerator SpawnerHorizontal(int enemy)
    {
        // spawner will work after 14 senconds in game
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
