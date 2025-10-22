using System.Collections.Generic;
using UnityEngine;
using Upgrade_Lib;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem Instance;

    [SerializeField] private List<Card> cards;

    [SerializeField] private bool developerMode;

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

        HideCards();

        ReloadUpgrades();
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

        if (!developerMode)
        {
            HideCards();
        }
    }

    public void ReloadUpgrades()
    {
        var json = Resources.Load<TextAsset>("Upgrades");

        UpgradeManager.LoadUpgrades(json.text);
    }

    private void HideCards()
    {
        foreach (var card in cards)
        {
            card.gameObject.SetActive(false);
        }
    }
}
