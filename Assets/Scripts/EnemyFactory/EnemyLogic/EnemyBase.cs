using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackDamage;
    [SerializeField] private int deathScore;
    
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        OnSpawn();
    }

    private protected abstract void OnSpawn();

    private void Update()
    {
        Vector2 direction = (GameManager.PlayerPosition - transform.position).normalized;

        rb.linearVelocity = direction * speed;

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Die()
    {
        Debug.Log($"Score to be added {deathScore}");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             Debug.Log("Player collided");
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet collided");
        }
    }
}
