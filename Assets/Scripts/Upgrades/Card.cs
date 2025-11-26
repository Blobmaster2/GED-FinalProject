using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrade_Lib;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    public string Title { 
        get { return title.text; }
        set { title.text = value; }
    }

    public string Description
    {
        get { return description.text; }
        set { description.text = value; }
    }

    public Upgrade upgrade;

    public void ApplyUpgrade()
    {
        UpgradeSystem.Instance.ApplyUpgrade(upgrade);
    }

    public void SetRarity(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:

                GetComponent<Outline>().effectColor = Color.white;

                break;

            case Rarity.Rare:

                GetComponent<Outline>().effectColor = new Color(1, 0.65f, 0);

                break;

            case Rarity.Epic:

                GetComponent<Outline>().effectColor = new Color(0.5f, 0, 0.5f);

                break;
            case Rarity.Legendary:

                GetComponent<Outline>().effectColor = Color.yellow;

                break;
        }
    }
}
