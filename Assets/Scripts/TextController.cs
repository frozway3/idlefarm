using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    Text text;
    [SerializeField] UpgradeSO upgrade;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    private void Update()
    {
        text.text = upgrade.upgradeType == UpgradeTypes.add
            ?"Price: "+Utilities.FormatNumber(upgrade.price)+"\nAdd: "+ Utilities.FormatNumber(upgrade.add)
            :"Price: "+ Utilities.FormatNumber(upgrade.price)+"\nGap: -"+ Utilities.FormatNumber(upgrade.gap)+" sec";
        if (upgrade.isMaxLvl)
        {
            text.text = "Max level";
        }
    }
}
