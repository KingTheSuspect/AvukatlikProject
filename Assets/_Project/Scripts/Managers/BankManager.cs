using UnityEngine;
using UnityEngine.Events;

public class BankManager : MonoBehaviour
{
    [Tooltip("If currency is lower or equals to this value bankrupt event will fire"),
    SerializeField] private int bankruptCurrencyValue = 100;

    public static event UnityAction OnCloseToBankrupt;

    private static bool HasEverCloseToBankrupt
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.HasEverCloseToBankruptKey, 0) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefsKeys.HasEverCloseToBankruptKey, value ? 1 : 0);
    }
    
    private void Start()
    {
        DataManager.OnCurrencyUpdate += HandleCurrencyUpdate;
    }

    private void HandleCurrencyUpdate()
    {
        if(HasEverCloseToBankrupt)
            return;
        
        if(DataManager.Currency <= bankruptCurrencyValue) //TODO prob will change this
        {
            OnCloseToBankrupt?.Invoke();
            HasEverCloseToBankrupt = true;
        }
    }

    private void OnDestroy()
    {
        DataManager.OnCurrencyUpdate -= HandleCurrencyUpdate;
    }
}
