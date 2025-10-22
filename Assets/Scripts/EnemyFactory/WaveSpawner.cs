using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float spawnCount = 3; // how many enemies to spawn according to the first wave
    [SerializeField] private float waveBasedSpawnScale = 1.2f; // scaling between spawn count on each wave
                                                        // (eg. first wave -> 10 enemies
                                                        // while second wave -> 12 enemies;
                                                        // thereby giving it a 1.2 increase in between spawns.)
    [SerializeField] private int spawnLevel = 1; // level of enemies that are spawning first wave
    [SerializeField] private float timeBetweenSpawns = 10; // time between spawns (not time between waves as time
                                                           // between waves will remain the same every wave
    [SerializeField] private int spawnRadiusMin = 5;  // the spawn radius around the player that the enemies are
    [SerializeField] private int spawnRadiusMax = 20; // allowed to spawn in

    [SerializeField] private string[] enemyIDs;
    
    private Vector2 playerPosition; // this variable is to replaced with a *global variable* that
                                        // keeps track of the player position

    private float spawnTimer;

    private int waveCount = 0;

    private EnemyFactory factory;
    
    // this script should run a timer and spawn enemies according to the level and abilities of the player
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        factory = GetComponent<EnemyFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DetermineSpawnCount()
    {
        // scales the spawn count depending on the current wave count
    }

    private void DetermineSpawnLevel()
    {
        // scales the spawned enemy levels depending on the wave count
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        float spawnDistance = Random.Range(spawnRadiusMin, spawnRadiusMax);
        
        Vector2 spawnPos = playerPosition + (spawnDirection * spawnDistance);
        
        return spawnPos;
    }

    private void CreateWave()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            factory.SpawnEnemy(enemyIDs[Random.Range(0, enemyIDs.Length)], GetRandomSpawnPosition());
        }
    }
    
    private void SpawnNextWave()
    {
        waveCount++;
        DetermineSpawnCount();
        DetermineSpawnLevel();
        CreateWave();
    }

}
