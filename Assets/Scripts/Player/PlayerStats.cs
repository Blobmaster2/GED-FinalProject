using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : Subject
{
    [SerializeField] private float maxHealth = 20;
    
    private float currentHealth;
    
    public float GetCurrentHealth() => currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player Health: " + currentHealth);
        currentHealth -= damage;
        NotifyObservers("hit");
    }
}
