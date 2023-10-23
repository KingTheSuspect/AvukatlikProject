using UnityEngine;
using UnityEngine.Events;

public class DataManager 
{
    private static int DefaultCurrency = 250;
    public static int Currency
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.CurrencyKey, DefaultCurrency);
        set 
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.CurrencyKey, value);
            OnCurrencyUpdate?.Invoke();
        }
    }
    public static event UnityAction OnCurrencyUpdate;

    public static int Level
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LevelKey, 1);
        set => PlayerPrefs.SetInt(PlayerPrefsKeys.LevelKey, value);
    }


    public static int Energy
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.EnergyKey, Managers.Instance.EnergyManager.EnergyConfig.MaxEnergyAmount);
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.EnergyKey, value);
            OnEnergyUpdate?.Invoke();
        } 
    }
    public static event UnityAction OnEnergyUpdate;


    private static int DefaultPrestige = 10;
    public static int Prestige
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.PrestigeKey, DefaultPrestige);
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.PrestigeKey, value);
            OnPrestigeUpdate?.Invoke();
        }
    }
    public static event UnityAction OnPrestigeUpdate;

    public static int LocalizationID
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.LocalizationKey, 0);
        set => PlayerPrefs.SetInt(PlayerPrefsKeys.LocalizationKey, value);
    }
}

public struct PlayerPrefsKeys
{
    public static string CurrencyKey = "Currency";
    public static string LevelKey = "Level";
    public static string PrestigeKey = "Prestige";
    public static string EnergyKey = "Energy";
    public static string LocalizationKey = "Localization";
    public static string EnergySpendTimeKey = "EnergySpendTime";
    public static string HasEverCloseToBankruptKey = "HasEverCloseToBankrupt";
}
