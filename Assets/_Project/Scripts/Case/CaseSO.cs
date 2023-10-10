using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Case")]
public class CaseSO : ScriptableObject
{
    [field: SerializeField] public int ID {get; private set;}
    [field: SerializeField] public string ComplainantName {get; private set;}
    [field: SerializeField, TextArea(1,1)] public string CaseSubject {get; private set;}
    [field: SerializeField, TextArea(5, 15)] public string CaseDescription {get; private set;}
    [field: SerializeField, TextArea(3,3)] public string CaseDescriptionByComplainant {get; private set;}
    [field: SerializeField, TextArea(3,6)] public string CaseSummaryByLawyer {get; private set;}

    [field: SerializeField] public CaseType CaseType {get; private set;}
    [field: SerializeField] public int Prestige {get; private set;} = 10;
    [field: SerializeField] public int CaseIncome {get; private set;} = 100; 


    [SerializeField, Expandable] private List<QuestionSO> questions;
}
