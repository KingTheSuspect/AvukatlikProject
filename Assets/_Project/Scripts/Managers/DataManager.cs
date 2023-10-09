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
}

public struct PlayerPrefsKeys
{
    public static string CurrencyKey = "Currency";
    public static string EnergyKey = "Energy";
    public static string EnergySpendTimeKey = "EnergySpendTime";
}
