using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJunkSpawner : MonoBehaviour
{
    [SerializeField] bool canSpawn = true;
    [SerializeField] GameObject EnemyPrefabs;
    [SerializeField] float spawnTime = 125f;         // wait until this second in game for the wave
    [SerializeField] float spawnRate = 0.1f;        // the amount of time between row spawn in the wave
    [SerializeField] int amountEachRow = 5;         // the amount of object in each row in the wave

    [SerializeField] float distanceInRow = 2;
    [SerializeField] float spawnPointX = -8f;
    [SerializeField] float spawnPoint2X = -6f;

    Vector2 spawnPoint;
    Vector2 spawnPoint2;

    private void Start()
    {
        StartCoroutine(SpawnJunk());
        spawnPoint = new Vector2(spawnPointX, transform.position.y);
        spawnPoint2 = new Vector2(spawnPoint2X, transform.position.y);
    }

    private IEnumerator SpawnJunk()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnTime);
        yield return wait;

        int rowIndex = 1;

        while (canSpawn && Boss.IsAlive)
        {
            if (rowIndex % 2 == 0)
            {
                for (int i = 0; i < amountEachRow; i++)
                {
                    Vector2 spawnPos = new Vector2(spawnPoint.x + i * distanceInRow, transform.position.y);
                    Instantiate(EnemyPrefabs, spawnPos, Quaternion.identity);
                }
            }
            else
            {
                for (int i = 0; i < amountEachRow; i++)
                {
                    Vector2 spawnPos = new Vector2(spawnPoint2.x + i * distanceInRow, transform.position.y);
                    Instantiate(EnemyPrefabs, spawnPos, Quaternion.identity);
                }
            }

            rowIndex++;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
