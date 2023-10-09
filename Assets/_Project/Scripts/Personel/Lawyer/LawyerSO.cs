using UnityEngine;

[CreateAssetMenu(menuName = "Personel/Lawyer", fileName = "NewLawyer")]
public class LawyerSO : PersonelSO
{
    [field: SerializeField, Range(1, 5)] public int SkillPoint {get; private set;}
}