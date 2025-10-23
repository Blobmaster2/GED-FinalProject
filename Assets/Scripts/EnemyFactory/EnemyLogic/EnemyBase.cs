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
    
    private void Start()
    {
        health = maxHealth;
        OnSpawn();
    }

    private protected abstract void OnSpawn();

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GameManager.PlayerPosition, 
            speed * Time.deltaTime);

        if (health <= 0)
        {
            Die();
        }
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
        else if (other.gameObject.CompareTag($"PlayerBullet"))
        {
            Debug.Log("Bullet collided");
        }
    }
}
