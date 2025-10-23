using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private float bulletSpawnOffset = 2;

    public T SpawnBullet<T>() where T : Bullet
    {
        var spawnPosition = transform.position;
        
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.AddComponent<T>();

        return bullet.GetComponent<T>();
    }
}
