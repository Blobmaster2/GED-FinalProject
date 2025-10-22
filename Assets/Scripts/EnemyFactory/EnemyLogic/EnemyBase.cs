using System;
using UnityEditor.UI;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackDamage;
    [SerializeField] private int deathScore;

    private Vector2 destinationPosition = new Vector2(); // this variable is to replaced with a *global variable* that
                                                         // keeps track of the player position
    
    private void Start()
    {
        health = maxHealth;
        OnSpawn();
    }

    private protected abstract void OnSpawn();

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destinationPosition, 
            speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        throw new NotImplementedException(); // add score addition here
    }
}
