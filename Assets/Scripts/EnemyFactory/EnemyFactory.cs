using UnityEngine;

public static class EnemyFactory
{
    public static void SpawnEnemy(string enemyID)
    {
        switch (enemyID)
        {
            case "bat":
                // spawn bat enemy
                break;
            case "walker":
                // spawn a walker
                break;
            default:
                // shows error
                break;
        }
    }
}
