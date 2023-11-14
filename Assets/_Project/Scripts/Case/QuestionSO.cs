using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Case/Question")]
public class QuestionSO : ScriptableObject
{
    [field: SerializeField] public LocalizedString Question {get; private set;}

    [SerializeField, Expandable] private List<AnswerSO> answers;

    [SerializeField, Expandable] private AnswerSO trueAnswer;

    public string GetQuestion => Question.GetLocalizedString();

    public AnswerSO GetAnswer(int index) => answers[index];

    public List<AnswerSO> Answers => answers;

    public AnswerSO TrueAnswer => trueAnswer;

    public bool IsTrueAnswer(AnswerSO answer) => trueAnswer == answer;
}
