using UnityEngine;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour
{
    [System.Serializable]
    public struct EnemyEntry
    {
        public string id;
        public GameObject prefab;
    }

    [SerializeField] private List<EnemyEntry> enemies;
    private Dictionary<string, GameObject> enemyMap;

    private void Awake()
    {
        enemyMap = new Dictionary<string, GameObject>();
        foreach (var entry in enemies)
        {
            if (!enemyMap.ContainsKey(entry.id))
                enemyMap.Add(entry.id, entry.prefab);
        }
    }

    public GameObject SpawnEnemy(string enemyID, Vector3 position)
    {
        if (enemyMap.TryGetValue(enemyID, out GameObject prefab))
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogError($"EnemyFactory: Unknown enemy ID '{enemyID}'");
            return null;
        }
    }
}