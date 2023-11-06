using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClientSystem")]
public class ClientSystem : ScriptableObject
{
    public string savePath;
    [SerializeField] private ClientDataBase personelDataBase;
    [SerializeField] private List<ClientSO> completedClientList = new();

    public List<ClientSO> CompletedClients => completedClientList;

    private IDataService dataService = new JsonDataService();

    public void Add(ClientSO personelSO)
    {
        if(completedClientList.Contains(personelSO))
            return;

        completedClientList.Add(personelSO); 

        Save();
    }
    public void Remove(ClientSO personelSO)
    {
        if(!completedClientList.Contains(personelSO))
            return;

        completedClientList.Remove(personelSO);
    }

    private List<int> personelIds = new();

    public void Clear()
    {
        completedClientList.Clear();
    }
    public void Save()
    {
        personelIds.Clear();
        foreach (var item in completedClientList)
            personelIds.Add(item.ID);
        
        dataService.SaveData(savePath, personelIds, true);
    }

    public void Load()
    {
        completedClientList.Clear();

        var data = dataService.LoadData<List<int>>(savePath, true);

        if(data == default)
        {
            return;
        }

        completedClientList = new(personelDataBase.GetPersonelByIDs(data));
    }
}
