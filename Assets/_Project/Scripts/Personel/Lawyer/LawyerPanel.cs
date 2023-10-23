using System.Collections.Generic;
using Lean.Pool;
using NaughtyAttributes;
using UnityEngine;

public class LawyerPanel : MonoBehaviour
{
    [SerializeField] private Transform contentParent;

    [SerializeField] private LawyerInfoUI lawyerInfoUIPrefab;

    [SerializeField] private PersonelDataBase lawyerDataBase;

    [SerializeField] private int lawyerTestValue = 5;

    [SerializeField] private List<LawyerSO> lawyerSOs;



    //this is temp, just for testing

    [Button]
    public void Init()
    {
        for (int i = 0; i < lawyerTestValue; i++)
        {
            LawyerSO lawyerSO = lawyerSOs[i < lawyerSOs.Count ? i : lawyerSOs.Count - 1];
            LeanPool.Spawn(lawyerInfoUIPrefab, contentParent).Init(lawyerSO);
        }
    }

    [Button]
    public void DeInit()
    {
        for (int i = contentParent.childCount - 1; i >= 0 ; i--)
        {
            LeanPool.Despawn(contentParent.GetChild(i));
        }
    }
}
