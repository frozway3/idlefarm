using System;
using System.Globalization;
using UnityEngine;

public static class Utilities
{
    public static void SetDateTime(string key, DateTime value)
    {
        string converted = value.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, converted);
    }
    public static DateTime GetDateTime(string key, DateTime value)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return value;
        }
    }
    public static string[] str = { "", "K", "M", "B", "T", "Qa", "Qi", "Sp" };
    public static string FormatNumber(float num)
    {
        int n = 0;
        while (num >= 1000)
        {
            n++;
            num /= 1000;
        }
        return num.ToString("#.#") + str[n];
    }
}
