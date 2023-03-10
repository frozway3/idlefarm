using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromocodesController : MonoBehaviour
{
    [SerializeField] InputField input;
    public Dictionary<string, bool> promocodes = new Dictionary<string, bool>(){
        { "pealkoforever", false},
        { "girlsday", false },
        { "chess", false },
        { "2023", false }
    };
    GameManager game = new GameManager();
    public void ClickOnLike()
    {
        var code = input.text;
        if (promocodes.ContainsKey(code))
        {
            if (!promocodes[code])
            {
                promocodes[code] = true;
                game.add *= 2;
                StartCoroutine(aboba("Success"));
            }
            else
            {
                StartCoroutine(aboba("it has been used"));
            }
        }
        else
        {
            StartCoroutine(aboba("wrong"));
        }
    }
    public void ClickOnDislike()
    {
        input.text = "";
    }
    IEnumerator aboba(string text)
    {
        input.text = text;
        yield return new WaitForSeconds(.9f);
        input.text = "";
    }
}
