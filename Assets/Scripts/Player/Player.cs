using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BulletFactory bulletFactory;

    public float moveSpeed { get; private set; } = 4f;
    public float speedMultiplier { get; private set; } = 1f;

    public float totalBulletCooldown { get; private set; } = 1.5f;
    public int bulletCount { get; private set; } = 1;
    public int bulletSpread { get; private set; } = 30;
    public float bulletSpeed { get; private set; } = 6f;
    public float bulletDamage { get; private set; } = 1f;

    private float bulletCooldown;
    private bool ableToShoot = true;

    private BulletType bulletType;

    void Update()
    {
        if (bulletCooldown < 0)
        {
            ableToShoot = true;
            bulletCooldown = totalBulletCooldown;
        }

        if (ableToShoot)
        {
            return;
        }

        bulletCooldown -= Time.deltaTime;
    }

    public void Shoot(Vector2 direction)
    {
        if (!ableToShoot)
        {
            return;
        }

        ableToShoot = false;

        switch (bulletType)
        {
            case BulletType.Standard:

                SpawnBullets(direction);

                break;

            //future cases
            case BulletType.Fire:
                break;
            case BulletType.Explosive:
                break;
        }
    }

    private void SpawnBullets(Vector2 direction)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            var bullet = bulletFactory.SpawnBullet<Bullet>();

            bullet.Initialize(true, bulletDamage, bulletSpeed, direction);
        }
    }
}
