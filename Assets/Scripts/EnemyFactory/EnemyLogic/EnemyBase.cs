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

    private bool canAttack;
    private float attackTimer;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        OnSpawn();
    }

    private protected abstract void OnSpawn();

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > attackCoolDown)
        {
            attackTimer = 0.0f;
            canAttack = true;
        }
        
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
        // Debug.Log($"Score to be added {deathScore}");
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("attack!");
            if (canAttack)
            {
                other.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
                canAttack = false;
                attackTimer = 0.0f; // to avoid rare but possible double attacks
            }
        }
    }
}
