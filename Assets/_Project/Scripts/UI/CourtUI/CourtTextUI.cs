using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CourtTextUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text courtText;

    private CourtTextPanelAdjuster adjuster;

    public event UnityAction OnTextComplete;

    private bool isTextTyping = false; 

    private void Awake()
    {
        adjuster = GetComponent<CourtTextPanelAdjuster>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isTextTyping)
            return;

        FinishText();
    }

    private void FinishText()
    {
        StopAllCoroutines();
        courtText.text = completeText;
        OnTextComplete?.Invoke();
        isTextTyping = false;
    }

    private string completeText = null;

    public void Init(string text)
    {
        text = Helpers.FixTMPOverlap(text, true); 
        courtText.text = text;
        completeText = text;

        StartCoroutine(ShowText());

        IEnumerator ShowText()
        {
            yield return null;
            adjuster.Adjust();
            yield return new WaitForSeconds(0.1f);
            isTextTyping = true;

            CourtUI.Instance.SetParent(transform);

            for (int i = 0; i <= text.Length; i++)
            {
                var currentText = text.Substring(0, i);
                courtText.text = currentText;
                yield return new WaitForSeconds(0.05f);
            }

            OnTextComplete?.Invoke();
            isTextTyping = false;
        }
    }

}
