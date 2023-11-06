using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Localization.Settings;
using TMPro;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private SettingsPanelOnOffButtons soundButtons;
    [SerializeField] private SettingsPanelOnOffButtons notificationButtons;

    [SerializeField] private Button closeButton;

    [SerializeField] private Button languageButton;

    [SerializeField] private TMP_Text languageText;

    [SerializeField] private Transform panel;

    [SerializeField] private float scaleDuration = 0.75f;   

    [SerializeField] private Button settingsWindow;

    private bool isActive = false;

    private void Awake()
    {
        soundButtons.OnButton.onClick.AddListener(HandleSoundOnButton);
        soundButtons.OffButton.onClick.AddListener(HandleSoundOffButton);

        notificationButtons.OnButton.onClick.AddListener(HandleNotificationOnButton);
        notificationButtons.OffButton.onClick.AddListener(HandleNotificationOffButton);

        closeButton.onClick.AddListener(HandleCloseButton);
        settingsWindow.onClick.AddListener(HandleCloseButton);
        languageButton.onClick.AddListener(HandleLanguageButton);

        gameObject.SetActive(false);
    }

    private void HandleLanguageButton()
    {
        const int languageCount = 3; 
        int localeId = DataManager.LocalizationID;

        if(localeId >= languageCount - 1)
        {
            localeId = 0;
        }
        else
            localeId++;

        DataManager.LocalizationID = localeId;
        languageText.text = Helpers.GetLanguage(localeId);

        StartCoroutine(Change());

        IEnumerator Change()
        {
            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[DataManager.LocalizationID];
        }
    }

    private void HandleSoundOffButton()
    {
        soundButtons.HandleOffButton();
        Managers.Instance.AudioManager.ToggleSound(false);
    }

    private void HandleSoundOnButton()
    {
        soundButtons.HandleOnButton();
        Managers.Instance.AudioManager.ToggleSound(true);
    }

    private void HandleNotificationOnButton()
    {
        notificationButtons.HandleOnButton();
    }

    private void HandleNotificationOffButton()
    {
        notificationButtons.HandleOffButton();
    }

    private void HandleCloseButton()
    {
        panel.transform.localScale = Vector3.one;
        PlayScaleAnimation(Vector3.zero, Ease.InBack, ()=> {
            gameObject.SetActive(false);
            isActive = false;
            });
    }

    public void Init()
    {
        if(isActive)
            return;
        
        isActive = true;
        gameObject.SetActive(true);
        panel.transform.localScale = Vector3.zero;
        languageText.text = Helpers.GetLanguage(DataManager.LocalizationID);
        PlayScaleAnimation(Vector3.one, Ease.OutBack, null);

        if(!AudioManager.MuteSfx)
            soundButtons.HandleOnButton();
        else
            soundButtons.HandleOffButton();

        //TODO handle notification
    }

    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        panel.transform.DOScale(target, scaleDuration).SetEase(easeType).OnComplete(()=> completeAction?.Invoke());
    }
}

[System.Serializable]
public class SettingsPanelOnOffButtons
{
    [field: SerializeField] public Button OnButton {get; private set;}
    [field: SerializeField] public Button OffButton {get; private set;}
    [field: SerializeField] public Button InactiveOnButton {get; private set;}
    [field: SerializeField] public Button InactiveOffButton {get; private set;}

    public void HandleOnButton()
    {
        OffButton.gameObject.SetActive(true);
        OnButton.gameObject.SetActive(false);
        InactiveOffButton.gameObject.SetActive(false);
        InactiveOnButton.gameObject.SetActive(true);
    }

    public void HandleOffButton()
    {
        OnButton.gameObject.SetActive(true);
        InactiveOnButton.gameObject.SetActive(false);
        OffButton.gameObject.SetActive(false);
        InactiveOffButton.gameObject.SetActive(true);
    }
    
}