using TMPro;
using UnityEngine;
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
}
