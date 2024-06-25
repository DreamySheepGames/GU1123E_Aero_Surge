using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2SpawnerHorizontalLeft : MonoBehaviour
{
    [SerializeField] float spawnRate = 0.5f;
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] int numberToSpawn = 10;

    public float timeStartSpawning = 3;

    private void Start()
    {
        StartCoroutine(SpawnerHorizontal(EnemyPrefabs));
    }
    private IEnumerator SpawnerHorizontal(GameObject[] EnemyPrefabs_)
    {
        // spawner will work after 14 senconds in game
        WaitForSeconds startToSpawn = new WaitForSeconds(timeStartSpawning);
        yield return startToSpawn;

        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        // spawn 2 waves, each wave has 10 ships
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                GameObject ship = Instantiate(EnemyPrefabs[0], transform.position, Quaternion.identity);
                ship.transform.rotation = Quaternion.Euler(0, 0, 90);
                yield return new WaitForSeconds(spawnRate);
            }

            yield return new WaitForSeconds(5);
        }
    }
}
