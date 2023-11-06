using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class Helpers
{
    public static string GetLanguage(int id)
    {
        switch(id)
        {
            case 0:
                return "ENGLISH";
            case 1:
                return "ESPANOL";
            case 2:
                return "TÜRKÇE";
            default:
                return "English";
        }
    }

    public static string FixTMPOverlap(string text, bool toUpper = false)
    {
        string newText = text.Replace("\r", "");

        return toUpper ? newText.ToUpper() : newText;
    }

    public static void DelaySeconds(this MonoBehaviour monoBehaviour, float seconds, UnityAction action)
    {
        monoBehaviour.StartCoroutine(DelayCoroutine());

        IEnumerator DelayCoroutine()
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }
    }
}