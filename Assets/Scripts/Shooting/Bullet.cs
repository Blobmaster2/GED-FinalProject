using UnityEngine;

public class Bullet : MonoBehaviour
{
    public const int PLAYER_LAYER = 3;
    public const int ENEMY_LAYER = 6;

    public const float TOTAL_LIFETIME = 5f;

    private float lifetime = 0;

    private void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime > TOTAL_LIFETIME && GameManager.DoPooling)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Initialize(
        bool isPlayerBullet, 
        float damage, 
        float speed, 
        Vector2 direction)
    {
        IsPlayerBullet = isPlayerBullet;
        Damage = damage;

        if (isPlayerBullet)
        {
            GetComponent<Collider2D>().excludeLayers = new LayerMask() { value = PLAYER_LAYER };
        }
        else
        {
            GetComponent<Collider2D>().excludeLayers = new LayerMask() { value = ENEMY_LAYER };
        }

        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }

    public bool IsPlayerBullet { get; private set; }
    public float Damage { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayerBullet)
        {
            if (collision.collider.gameObject.layer == ENEMY_LAYER)
            {
                collision.gameObject.GetComponent<EnemyBase>().TakeDamage(20); // this value should probably be changed
                Destroy(gameObject);
            }
        }
        else if (collision.collider.gameObject.layer == PLAYER_LAYER)
        {
            //damage player
        }
    }
}

public enum BulletType
{
    Standard,
    Fire,
    Explosive
}