using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CourtAnswerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text answerText;
    [SerializeField] private Button button;
    [SerializeField] private CourtUI courtUI;
    [SerializeField] private Image buttonImage;
    private bool isTrueAnswer;
    private AnswerSO answerSO;

    public bool IsTrueAnswer => isTrueAnswer;

    private void Awake()
    {
        button.onClick.AddListener(HandleButton);

        EnableButton(false);
        buttonImage.enabled = false;
        answerText.text = string.Empty;
    }


    //bir cevap secildikten sonra cevaplarin hepsi gizleniyor yeni soru geldikten sonra yani init cagirildiginda tekrar goruyoruz
    //eger bunu istemezsek bunu silip yerine sadece button interactable false yapabiliriz
    public void Hide()
    {
        buttonImage.enabled = false;
        answerText.text = string.Empty;
        EnableButton(false);
    }

    private void EnableButton(bool enabled) => button.interactable = enabled;

    public void HandleButton()
    {
        if(answerSO == null)
            return;

        if(isTrueAnswer)
            CourtUI.CurrentTrueAnswerCount++;

        Debug.LogError(isTrueAnswer);
        courtUI.AddLawyerText(answerSO.GetAnswer);
    }

    public void Init(AnswerSO answerSO, bool isTrueAnswer)
    {
        EnableButton(true);
        buttonImage.enabled = true;

        answerText.text = answerSO.GetAnswer;
        this.isTrueAnswer = isTrueAnswer;
        this.answerSO = answerSO;
    }

}
