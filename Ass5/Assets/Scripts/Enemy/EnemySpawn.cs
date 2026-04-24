using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int spawnCount = 0;
    [SerializeField] int spawnAmount = 5;
    [SerializeField] float timeUntilSpawn = 1f;
    [SerializeField] float minSpawnTime = 3f;
    [SerializeField] float maxSpawnTime = 3f;

    private void Awake()
    {
        spawnCount = 0;
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        if (spawnCount >= spawnAmount)
            return;

        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-28, 28), 0, Random.Range(-15, 15));

            Instantiate(enemyPrefab, position, Quaternion.Euler(0, 0, 0));
            spawnCount++;
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
