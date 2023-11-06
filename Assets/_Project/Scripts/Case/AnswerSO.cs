using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Case/Answer")]
public class AnswerSO : ScriptableObject
{
    [field: SerializeField] public LocalizedString Answer {get; private set;}

    public string GetAnswer => Answer.GetLocalizedString();
}
