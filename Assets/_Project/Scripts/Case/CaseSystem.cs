using System.Collections.Generic;
using UnityEngine;

public class CaseSystem : ScriptableObject
{
    [SerializeField] private string savePath;
    [SerializeField] private CaseDataBase caseDataBase;
    [SerializeField] private List<CaseSO> caseList;

    public List<CaseSO> Cases => caseList;

    private IDataService dataService = new JsonDataService();

    public void Add(CaseSO caseSO)
    {
        if(caseList.Contains(caseSO))
            return;

        caseList.Add(caseSO); 
    }
    public void Remove(CaseSO caseSO)
    {
        if(!caseList.Contains(caseSO))
            return;

        caseList.Remove(caseSO);
    }

    private List<int> caseIds = new();

    public void Clear()
    {
        caseList.Clear();
    }
    public void Save()
    {
        caseIds.Clear();
        foreach (var item in caseList)
            caseIds.Add(item.ID);
        
        dataService.SaveData(savePath, caseIds, true);
    }

    public void Load()
    {
        caseList.Clear();

        var data = dataService.LoadData<List<int>>(savePath, true);

        foreach (int personelID in data)
        {
            if(caseDataBase.TryGetCase(personelID, out CaseSO caseSO))
                caseList.Add(caseSO);
        }
    }
}
