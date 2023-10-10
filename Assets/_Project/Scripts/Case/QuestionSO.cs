using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Case/Question")]
public class QuestionSO : ScriptableObject
{
    [field: SerializeField, TextArea(3,3)] public string Question {get; private set;}

    [SerializeField, Expandable] private List<AnswerSO> answers;

    [SerializeField, Expandable] private AnswerSO trueAnswer;
}
