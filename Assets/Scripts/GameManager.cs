using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float money
    {
        get => PlayerPrefs.GetFloat("money");
        set => PlayerPrefs.SetFloat("money", value);
    }
    [HideInInspector] public float add
    {
        get => PlayerPrefs.GetFloat("add", 0.1f);
        set => PlayerPrefs.SetFloat("add", value);
    }
    [HideInInspector] public float gap
    {
        get => PlayerPrefs.GetFloat("gap", 10);
        set => PlayerPrefs.SetFloat("gap", value);
    }
    [SerializeField] Text moneyText, addText, gapText;
    [SerializeField] UpgradeSO[] ALLUPGRADES;
    bool off = true;
    void Start()
    {
        StartCoroutine(GetMoney());
    }
    void Update()
    {
        moneyText.text = money>0? Utilities.FormatNumber(money)+" money" : "0 money";
        addText.text = add > 0 ? Utilities.FormatNumber(add)+" add" : "0 add";
        gapText.text = money > 0 ? gap.ToString("#.#")+" gap" : "0 gap";
    }
    public void DeletePP()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < ALLUPGRADES.Length; i += 2)
        {
            ALLUPGRADES[i].price = ALLUPGRADES[i + 1].price;
        }
    }
    public void ToggleSettings(GameObject panel)
    {
        panel.SetActive(off);
        off = !off;
    }
    public void Upgrade(UpgradeSO upgrade)
    {
        if (money >= upgrade.price)
        {
            money -= upgrade.price;
            add += upgrade.add;
            gap -= upgrade.gap;
            upgrade.price *= 1.5f;
        }
    }
    IEnumerator GetMoney()
    {
        while (true)
        {
            money += add;
            yield return new WaitForSeconds(gap);
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            Utilities.SetDateTime("lastSave", DateTime.UtcNow);
        } else
        {
            DateTime lastSave = Utilities.GetDateTime("lastSave", DateTime.UtcNow);
            TimeSpan span = DateTime.UtcNow - lastSave;
            float totalSec = Mathf.Clamp((float)span.TotalSeconds, 0, 60*60*24*365);
            money += totalSec / gap * add;
        }
    }
}
