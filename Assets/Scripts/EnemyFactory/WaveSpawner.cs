using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private int spawnCount; // how many enemies to spawn according to the first wave
    [SerializeField] private float waveBasedSpawnScale; // scaling between spawn count on each wave
                                                        // (eg. first wave -> 10 enemies
                                                        // while second wave -> 12 enemies;
                                                        // thereby giving it a 1.2 increase in between spawns.)
    [SerializeField] private int spawnLevel; // level of enemies that are spawning first wave
    [SerializeField] private float timeBetweenSpawns; // time between spawns (not time between waves as time between
                                                      // waves will remain the same every wave
    [SerializeField] private int spawnRadiusMin; // the spawn radius around the player that the enemies are allowed to
    [SerializeField] private int spawnRadiusMax; // spawn in

    [SerializeField] private string[] enemyIDs;
    
    private Vector2 destinationPosition; // this variable is to replaced with a *global variable* that
                                        // keeps track of the player position

    private float spawnTimer;
    
    private List<string> enemyPool = new List<string>();
                                                         

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
        
    }

    private void DetermineSpawnLevel()
    {
        
    }

    private void CreateWave()
    {
        
    }
    
    private void SpawnNextWave()
    {
        waveCount++;
        DetermineSpawnCount();
        DetermineSpawnLevel();

    }

}
