using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float spawnCount = 3; // how many enemies to spawn according to the first wave
    [SerializeField] private float baseSpawnCount = 3; // default enemy spawn count used for wave scaling

    [SerializeField] private float waveBasedSpawnScale = 1.2f; // scaling between spawn count on each wave

    // (eg. first wave -> 10 enemies
    // while second wave -> 12 enemies;
    // thereby giving it a 1.2 increase in between spawns.)
    [SerializeField] private int spawnLevel = 1; // level of enemies that are spawning first wave

    [SerializeField] private float timeBetweenSpawns = 30; // time between spawns (not time between waves as time

    // between waves will remain the same every wave
    [SerializeField] private int spawnRadiusMin = 5; // the spawn radius around the player that the enemies are
    [SerializeField] private int spawnRadiusMax = 20; // allowed to spawn in

    [SerializeField] private string[] enemyIDs;

    private Vector2 playerPosition; // this variable is to replaced with a *global variable* that
    // keeps track of the player position

    private float spawnTimer;

    private int waveCount = 0; // will be used in the future iteration

    private EnemyFactory factory;

    private bool allEnemiesDead = false;

    // this script should run a timer and spawn enemies according to the level and abilities of the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        factory = GetComponent<EnemyFactory>();
        spawnTimer = timeBetweenSpawns;

        factory.OnEnemyDead += HandleEnemyDead;
    }

    private void HandleEnemyDead()
    {
        if (factory.spawnedEnemies.TrueForAll(enemy => !enemy.activeInHierarchy))
        {
            allEnemiesDead = true;
        }
        else
        {
            allEnemiesDead = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeBetweenSpawns)
        {
            spawnTimer = 0;
            
            if (allEnemiesDead)
            {
                if (GameManager.DoPooling)
                {
                    SpawnNextWave();
                    allEnemiesDead = false;
                }
                else
                {
                    SpawnNextWave();
                }
            }
        }
    }

    private void DetermineSpawnCount()
    {
        // scales the spawn count depending on the current wave count
        //bad code
        float scaled = spawnCount * Mathf.Pow(waveBasedSpawnScale, waveCount - 1);
        spawnCount = Mathf.RoundToInt(scaled);

        //good code
        //float scaled = baseSpawnCount * Mathf.Pow(waveBasedSpawnScale,waveCount - 1);
        //spawnCount = Mathf.RoundToInt(scaled);
    }

    private void DetermineSpawnLevel()
    {
        // scales the spawned enemy levels depending on the wave count
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnDirection = Random.insideUnitCircle.normalized; // its a circle, so, 2D, i.e., Vector2
        float spawnDistance = Random.Range(spawnRadiusMin, spawnRadiusMax);

        Vector3 spawnPos = GameManager.PlayerPosition + (spawnDirection * spawnDistance); // put in parentheses
        // for easy readability

        return spawnPos;
    }

    private void CreateWave()
    {
        if (GameManager.DoPooling)
        {
            int enemiesInList = factory.spawnedEnemies.Count;
            int targetCount = Mathf.RoundToInt(spawnCount);
            int reused = 0;

            for (int i = 0; i < enemiesInList; i++)
            {
                GameObject enemy = factory.spawnedEnemies[i];
                Debug.Log(enemy);
                enemy.transform.position = GetRandomSpawnPosition();
                enemy.SetActive(true);
                reused++;
            }

            int newSpawnCount = Mathf.Max(0, targetCount - reused);

            for (int i = 0; i < newSpawnCount; i++)
            {
                factory.SpawnEnemy(enemyIDs[Random.Range(0, enemyIDs.Length)], GetRandomSpawnPosition());
            }
        }
        else
        {
            for (int i = 0; i < spawnCount; i++)
            {
                factory.SpawnEnemy(enemyIDs[Random.Range(0, enemyIDs.Length)], GetRandomSpawnPosition());
            }
        }
    }

    private void SpawnNextWave()
    {
        Debug.Log("Spawning next wave");
        waveCount++;
        DetermineSpawnCount();
        DetermineSpawnLevel();
        CreateWave();
    }
}