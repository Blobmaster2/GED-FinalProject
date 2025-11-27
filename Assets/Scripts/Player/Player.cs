using UnityEngine;

public class Player : Subject
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

    public int CurrentLevel
    {
        get => currentLevel;
        set
        {
            currentLevel = value;
            UpgradeSystem.Instance.RollCards();
            Debug.Log("level: " + currentLevel);
            Debug.Log("xp :" + xp);
        }
    }

    private int currentLevel = 0;
    private float xp;

    public float XP
    {
        get => xp;
        set
        {
            xp = value;
            GetLevelProgress();
        }
    }

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
        
        NotifyObservers("shoot"); // plays the audio

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
        float halfCone = 45 / 2f;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = 0f;

            if (bulletCount > 1)
            {
                float t = i / (float)(bulletCount - 1);   // goes 0 → 1
                angle = Mathf.Lerp(-halfCone, halfCone, t);
            }

            // Rotate the base direction
            Vector2 dir = RotateVector(direction, angle);

            var bullet = bulletFactory.SpawnBullet<Bullet>();

            bullet.Initialize(true, bulletDamage, bulletSpeed, dir);
        }
    }

    Vector2 RotateVector(Vector2 v, float degrees)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);

        return new Vector2(
            v.x * cos - v.y * sin,
            v.x * sin + v.y * cos
        );
    }

    public float GetLevelProgress()
    {
        float A = 3.5f;
        float B = -15f;
        float C = 0f;

        var level = Mathf.Max(Mathf.FloorToInt((A * Mathf.Log(xp + C)) + B), 0);

        Debug.Log("Level: " + level + " xp: " + xp);

        if (CurrentLevel < level)
        {
            CurrentLevel = level;
        }

        int nextLevel = CurrentLevel + 1;

        float xpAtCurrent = Mathf.Exp((CurrentLevel - B) / A) - C;
        float xpAtNext = Mathf.Exp((nextLevel - B) / A) - C;

        float xpIntoLevel = xp - xpAtCurrent;
        float xpNeeded = xpAtNext - xpAtCurrent;

        return Mathf.Clamp01(xpIntoLevel / xpNeeded);
    }

    public static Player GetPlayer()
    {
        var obj = GameObject.Find("Player");
        if (obj)
        {
            return obj.GetComponent<Player>();
        }
        return null;
    }
}
