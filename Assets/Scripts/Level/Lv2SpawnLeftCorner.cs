using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2SpawnLeftCorner : MonoBehaviour
{
    [SerializeField] float spawnRate = 0.5f;
    [SerializeField] GameObject[] EnemyPrefabs;
    public bool canSpawn = true;
    public float timeStartSpawning = 1f;
    public float timeEndSpawning = 10f;
    public float randDistance = 8f;

    private void Start()
    {
        StartCoroutine(SpawnDiagonal(EnemyPrefabs));
        StartCoroutine(StopSpawning());
    }

    IEnumerator SpawnDiagonal(GameObject[] EnemyPrefabs_)
    {
        yield return new WaitForSeconds(timeStartSpawning);
        
        while(canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            Vector2 spawnPoint = new Vector2(Random.RandomRange(transform.position.x - randDistance, transform.position.x + randDistance), transform.position.y);
            GameObject meteor = Instantiate(EnemyPrefabs_[0], spawnPoint, Quaternion.identity);
            meteor.transform.rotation = Quaternion.Euler(0, 0, 45);
        }

    }

    IEnumerator StopSpawning()
    {
        yield return new WaitForSeconds(timeEndSpawning);
        canSpawn = false;
    }
}
