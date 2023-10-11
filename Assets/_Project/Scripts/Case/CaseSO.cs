using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Case")]
public class CaseSO : ScriptableObject
{
    [field: SerializeField] public int ID {get; private set;}
    [field: SerializeField] public string ComplainantName {get; private set;}
    [field: SerializeField] public LocalizedString CaseSubject {get; private set;}
    [field: SerializeField] public LocalizedString CaseDescription {get; private set;} 
    [field: SerializeField] public LocalizedString CaseDescriptionByComplainant {get; private set;}
    [field: SerializeField] public LocalizedString CaseSummaryByLawyer {get; private set;}

    [field: SerializeField] public CaseType CaseType {get; private set;}
    [field: SerializeField] public int Prestige {get; private set;} = 10;
    [field: SerializeField] public int CaseIncome {get; private set;} = 100; 


    [SerializeField, Expandable] private List<QuestionSO> questions;

    public List<QuestionSO> Questions => questions;
}
