using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class TestCaseUI : MonoBehaviour
{
    [SerializeField] private CaseSO caseSO;

    [SerializeField] private TMP_Text testText;

    [SerializeField] private int questionIndex;
    [SerializeField] private int answerIndex;

    private void Awake()
    {
        testText.text = "test";
    }

    [Button]
    private void SetQuestion()
    {
        testText.text = caseSO.Questions[questionIndex].Question.GetLocalizedString();
    }

    [Button]
    private void SetDesc()
    {
        testText.text = caseSO.CaseDescription.GetLocalizedString();
    }

    [Button]
    private void SetCaseSummary()
    {
        testText.text = caseSO.CaseSummaryByLawyer.GetLocalizedString();
    }

    [Button]
    private void SetAnswer()
    {
        testText.text = caseSO.Questions[questionIndex].Answers[answerIndex].Answer.GetLocalizedString();
    }

    [Button]
    private void SetTrueAnswer()
    {
        testText.text = caseSO.Questions[questionIndex].TrueAnswer.Answer.GetLocalizedString();
    }
}
