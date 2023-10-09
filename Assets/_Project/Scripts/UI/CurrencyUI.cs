using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    [SerializeField] private int testValue = 1000;

    [SerializeField] private float currencyTextUpdateDuration = 0.65f;

    [SerializeField] private float scaleMultiplier = 1.3f;
    [SerializeField] private float scaleInterval = 0.1f;

    private int lastCurrency;

    private void Awake()
    {
        moneyText.text = DataManager.Currency.FormatCurrency();

        DataManager.OnCurrencyUpdate += HandleCurrencyUpdate;

        lastCurrency = DataManager.Currency;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(Input.GetMouseButtonDown(0))
        {
            DataManager.Currency += testValue;
        }
        if(Input.GetMouseButtonDown(1))
        {
            DataManager.Currency -= testValue;
        }
    }
#endif

    private void OnDestroy()
    {
        DataManager.OnCurrencyUpdate -= HandleCurrencyUpdate;
    }

    private void HandleCurrencyUpdate()
    {
        moneyText.transform.DOScale(Vector3.one * scaleMultiplier, scaleInterval).SetLoops(-1, LoopType.Yoyo);

        DOTween.To(()=> lastCurrency, x=> lastCurrency = x, DataManager.Currency, currencyTextUpdateDuration).
        SetEase(Ease.OutCirc).
        OnUpdate(()=> 
        {
            moneyText.text = lastCurrency.FormatCurrency();
        }).OnComplete(()=> 
        {
            moneyText.transform.DOKill();
            moneyText.transform.DOScale(Vector3.one, scaleInterval);
        });
    }
}

public static class CurrencyFormatter
{
    public static string FormatCurrency(this int number)
    {
        if (number >= 1e9f) // 1 milyar ve üzeri
        {
            return (number / 1e9f).ToString("F0") + "B";
        }
        else if (number >= 1e6f) // 1 milyon ve üzeri
        {
            string formatted = (number / 1e6f).ToString("F1");
            if(formatted.EndsWith('0'))
            {
                formatted = (number / 1e6f).ToString("F0");
            }
            else
            {

            }
            return formatted  + "M";
        }
        else if (number >= 1e3f) // 1 bin ve üzeri
        {
            return (number / 1e3f).ToString("F0") + "K";
        }
        else
        {
            return number.ToString("F0"); // Diğer durumlar için tam sayı olarak göster
        }
    }
}
