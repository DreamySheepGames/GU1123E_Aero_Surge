using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2WallSpawner : MonoBehaviour
{
    public GameObject spaceJunkPrefab;                  // Regular space junk prefab
    public GameObject destructibleSpaceJunkPrefab;      // Destructible space junk prefab
    public int rowLength = 5;                           // Number of junks in a row
    public int rowNumber = 8;                           // Number of rows
    public float brickSpacing = 2f;                     // Space between junks
    public float startSpawnAt = 1f;
    public float spawnRate = 3.5f;

    void Start()
    {
        StartCoroutine(SpawnBrickRow());
    }

    IEnumerator SpawnBrickRow()
    {
        yield return new WaitForSeconds(startSpawnAt);

        // Determine the position for the first brick
        Vector2 startPosition = transform.position;

        for (int j = 0; j < rowNumber; j++)
        {
            // Choose a random index for the destructible brick
            int destructibleBrickIndex = Random.Range(0, rowLength);

            for (int i = 0; i < rowLength; i++)
            {
                // Calculate the position for each brick
                Vector2 brickPosition = startPosition + new Vector2(i * brickSpacing, 0);

                // Determine which prefab to use
                GameObject brickToSpawn = (i == destructibleBrickIndex) ? destructibleSpaceJunkPrefab : spaceJunkPrefab;

                // Spawn the brick
                Instantiate(brickToSpawn, brickPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnRate);
        }

        
    }
}
