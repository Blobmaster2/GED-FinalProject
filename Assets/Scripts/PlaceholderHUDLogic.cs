using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceholderHUDLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image xpBar;
    
    [SerializeField] private PlayerStats playerStats;

    private void Update()
    {
        scoreText.text = $"Score: {GameManager.PlayerScore}";

        healthText.text = $"Health: {playerStats.GetCurrentHealth()}";

        xpBar.fillAmount = Player.GetPlayer().GetLevelProgress();
    }
}
