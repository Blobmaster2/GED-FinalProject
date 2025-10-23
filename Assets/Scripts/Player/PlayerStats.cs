using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20;
    
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player Died!");
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player Health: " + currentHealth);
        currentHealth -= damage;
    }
}
