using System;
using TMPro;
using UnityEngine;

public class PlaceholderHUDLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    
    [SerializeField] private PlayerStats playerStats;

    private void Update()
    {
        scoreText.text = $"Score: {GameManager.PlayerScore}";

        healthText.text = $"Health: {playerStats.GetCurrentHealth()}";
    }
}
