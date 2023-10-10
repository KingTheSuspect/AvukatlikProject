using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Case/Answer")]
public class AnswerSO : ScriptableObject
{
    [field: SerializeField, TextArea(3,3)] public string Answer {get; private set;}
}
