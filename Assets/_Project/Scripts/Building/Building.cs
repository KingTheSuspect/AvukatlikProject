using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using System.Collections.Generic;

public class Building : MonoBehaviour, IBuyable, IUpgradable
{
    [field: SerializeField, Expandable] public BuildingSO BuildingSO {get; private set;}
    [SerializeField] private BuildingData buildingData;

    [SerializeField] private List<PersonelSO> personels;

    private bool IsBuyable => DataManager.Currency >= BuildingSO.BuyPrice;
    private bool IsUpgradable => buildingData.Level < BuildingSO.MaxLevel && DataManager.Currency >= BuildingSO.UpgradePriceByLevels[buildingData.Level - 1];
    private IDataService dataService = new JsonDataService();
    
    public event UnityAction OnBought; //for later on purposes

    public int CurrentLevel => buildingData.Level;
    public List<PersonelSO> GetPersonels() => personels;
    
    public void AddPersonel(PersonelSO personelSO)
    {
        if(personels.Contains(personelSO))
            return;
        
        personels.Add(personelSO);
        buildingData.PersonelIDs.Add(personelSO.ID);
    }

    public void RemovePersonel(PersonelSO personelSO)
    {
        if(!personels.Contains(personelSO))
            return;
        
        personels.Remove(personelSO);
        buildingData.PersonelIDs.Remove(personelSO.ID);
    }

    public void Buy()
    {
        if(!IsBuyable)
            return;

        Managers.Instance.BuildingManager.Add(this);
        OnBought?.Invoke();
    }
    
    [Button]
    public void Upgrade()
    {
        if(!IsUpgradable)
            return;
        
        //upgrade logic here
        buildingData.Upgrade();
    }

    private void OnDisable()
    {
        Save();
    }

    [Button]
    private void Load()
    {
        int id = gameObject.GetInstanceID();
        var data = dataService.LoadData<BuildingData>($"Building{id}.save", true);

        buildingData = data;

        personels = new(BuildingSO.PersonelDataBase.GetPersonelByIDs(buildingData.PersonelIDs));
    }

    private void Save()
    {
        int id = gameObject.GetInstanceID();
        dataService.SaveData($"Building{id}.save", buildingData, true);
    }
}

[System.Serializable]
public class BuildingData
{
    [field: SerializeField] public int Level {get; set;} = 1;
    [field: SerializeField] public List<int> PersonelIDs {get; set;}

    public void Upgrade()
    {
        Level++;
    }
}