using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class Building : MonoBehaviour, IBuyable, IUpgradable
{
    [field: SerializeField, Expandable] public BuildingSO BuildingSO {get; private set;}
    [SerializeField] private BuildingData buildingData;

    public event UnityAction OnBought; //for later on purposes

    private bool IsBuyable => DataManager.Currency >= BuildingSO.BuyPrice;

    private IDataService dataService = new JsonDataService();

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
        //upgrade logic here
        buildingData.Level ++;
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
    [field: SerializeField] public int CurrentRent {get; set;}
}