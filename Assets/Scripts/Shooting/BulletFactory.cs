using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    public T SpawnBullet<T>() where T : Bullet
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.AddComponent<T>();

        return bullet.GetComponent<T>();
    }
}
