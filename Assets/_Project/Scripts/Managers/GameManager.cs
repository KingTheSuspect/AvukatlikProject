using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(SetLocalization());
        Application.targetFrameRate = 60;
    }

    private IEnumerator SetLocalization()
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[DataManager.LocalizationID];
    }
}
