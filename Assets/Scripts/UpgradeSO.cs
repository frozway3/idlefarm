using UnityEngine;
[CreateAssetMenu(fileName="Upgrade 1")]
public class UpgradeSO : ScriptableObject
{
    public UpgradeTypes upgradeType;
    [Header("Если этот скриптабл обжект добавляет к add")]
    public float add;
    [Header("то сделайте gap = 0")]
    public float price;
    [Header("если отнимает gap то сделайте add = 0")]
    public float gap;
}
