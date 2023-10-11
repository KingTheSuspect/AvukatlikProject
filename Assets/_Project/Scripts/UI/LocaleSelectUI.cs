using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocaleSelectUI : MonoBehaviour
{
    [SerializeField] private int localeID;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        StartCoroutine(Change());
        IEnumerator Change()
        {
            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
            DataManager.LocalizationID = localeID;
        }
    }
}
