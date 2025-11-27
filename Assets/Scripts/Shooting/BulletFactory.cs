using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private List<GameObject> bulletPool = new List<GameObject>();
    private int maxBulletCount = 100;

    public T SpawnBullet<T>() where T : Bullet
    {
        var spawnPosition = transform.position;
        
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.AddComponent<T>();

        if (GameManager.DoPooling) //for profiling
        {
            bulletPool.Add(bullet);

            if (bulletPool.Count > maxBulletCount)
            {
                Destroy(bulletPool[0]);
                bulletPool.RemoveAt(0);
            }
        }

        return bullet.GetComponent<T>();
    }
}
