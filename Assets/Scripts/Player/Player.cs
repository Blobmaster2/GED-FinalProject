using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BulletFactory bulletFactory;

    public float moveSpeed = 4f;
    public float speedMultiplier = 1f;

    public float TotalBulletCooldown
    {
        get => totalBulletCooldown;
        set
        {
            totalBulletCooldown = value;
            bulletCooldown = 0;
        }
    }

    private float totalBulletCooldown = 1.5f;

    public int bulletCount = 1;
    public int bulletSpread = 30;
    public float bulletSpeed = 6f;
    public float bulletDamage = 1f;

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

    public static Player GetPlayer()
    {
        return GameObject.Find("Player").GetComponent<Player>();
    }
}
