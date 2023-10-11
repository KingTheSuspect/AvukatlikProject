using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PersonelSystem")]
public class PersonelSystem : ScriptableObject
{
    public string savePath;
    [SerializeField] private PersonelDataBase personelDataBase;
    [SerializeField] private List<PersonelSO> personelList;

    public List<PersonelSO> Personels => personelList;

    private IDataService dataService = new JsonDataService();

    public void Add(PersonelSO personelSO)
    {
        if(personelList.Contains(personelSO))
            return;

        personelList.Add(personelSO); 
    }
    public void Remove(PersonelSO personelSO)
    {
        if(!personelList.Contains(personelSO))
            return;

        personelList.Remove(personelSO);
    }

    private List<int> personelIds = new();

    public void Clear()
    {
        personelList.Clear();
    }
    public void Save()
    {
        personelIds.Clear();
        foreach (var item in personelList)
            personelIds.Add(item.ID);
        
        dataService.SaveData(savePath, personelIds, true);
    }

    public void Load()
    {
        personelList.Clear();

        var data = dataService.LoadData<List<int>>(savePath, true);

        personelList = new(personelDataBase.GetPersonelByIDs(data));
    }
}
