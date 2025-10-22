using System.Collections.Generic;
using UnityEngine;
using Upgrade_Lib;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem Instance;

    [SerializeField] private List<Card> cards;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        foreach (var card in cards)
        {
            gameObject.SetActive(false);
        }
    }

    public void RollCards()
    {
        foreach (var card in cards)
        {
            var upgrade = UpgradeManager.GetRandomUpgrade();

            card.upgrade = upgrade;

            card.Title = upgrade.Name;
            card.Description = upgrade.Description;

            card.gameObject.SetActive(true);
        }
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        UpgradeInterpreter.ApplyUpgrade(upgrade, Player.GetPlayer());
    }
}
