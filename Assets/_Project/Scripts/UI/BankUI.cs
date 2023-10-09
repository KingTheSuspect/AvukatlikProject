using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BankUI : MonoBehaviour
{
    [SerializeField] private Transform bankPanel;
    [SerializeField] private float scaleDuration = 0.65f;

    [SerializeField] private Button bankButton;
    [SerializeField] private Button getButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private TMP_Text currencyAmountText;

    private void Awake()
    {
        bankButton.onClick.AddListener(HandleBankButton);
        getButton.onClick.AddListener(HandleGetButton);
        closeButton.onClick.AddListener(HandleCloseButton);
        bankPanel.gameObject.SetActive(false);
    }

    private void Start()
    {
        BankManager.OnCloseToBankrupt += HandleCloseToBankrupt;
    }

    private void HandleCloseToBankrupt()
    {
        int testValue = 5000; 
        currencyAmountText.text = testValue.ToString(); 
        InitBankPanel();
    }

    private void HandleCloseButton()
    {
        PlayScaleAnimation(Vector3.zero, Ease.InBack, ()=> bankPanel.gameObject.SetActive(false));
    }

    private void HandleGetButton()
    {
        int amount = int.Parse(currencyAmountText.text);
        DataManager.Currency += amount;

        PlayScaleAnimation(Vector3.zero, Ease.InBack, ()=> bankPanel.gameObject.SetActive(false));
    }

    private void HandleBankButton()
    {
        InitCurrencyText();
        InitBankPanel();
    }

    private void InitCurrencyText()
    {
        //TODO prob will change the logic
        int randomMultiplier = Random.Range(3, 10);
        int currency = DataManager.Currency;
        int randomValue = currency * randomMultiplier;
        currencyAmountText.text = randomValue.ToString();
    }

    private void InitBankPanel()
    {
        bankPanel.gameObject.SetActive(true);
        bankPanel.transform.localScale = Vector3.zero;
        PlayScaleAnimation(Vector3.one, Ease.OutBack, null);
    }

    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        bankPanel.transform.DOScale(target, scaleDuration).SetEase(easeType).OnComplete(()=> completeAction?.Invoke());
    }

    private void OnDestroy()
    {
        BankManager.OnCloseToBankrupt -= HandleCloseToBankrupt;
    }
}
