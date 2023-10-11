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

    public List<AnswerSO> Answers => answers;

    public AnswerSO TrueAnswer => trueAnswer;
}
