using System.Collections.Generic;
using UnityEngine;

public class OfficeItem : MonoBehaviour
{
    [SerializeField] private List<GameObject> models;
    [SerializeField] private OfficeItemData officeItemData;
    [SerializeField] private string itemName;

    [field: SerializeField] public OfficeItemType OfficeItemType {get; private set;}

    private IDataService dataService = new JsonDataService();

    private Office office;

    public int CurrentID => officeItemData.Id;

    public void SetID(int id ) => officeItemData.Id = id;

    public void Init(Office office)
    {
        this.office = office;
        Load();
    }

    private void Visualize()
    {
        for (int i = 0; i < models.Count; i++)
        {
            models[i].SetActive(i == officeItemData.Id);
        }
    }

    private void Load()
    {
        officeItemData = dataService.LoadData<OfficeItemData>($"{office.SavePath}{itemName}", true);
        Visualize();
    }

    private void Save()
    {
        dataService.SaveData($"{office.SavePath}{itemName}", officeItemData, true);
    }

    private void OnDisable()
    {
        Save();
    }
}

[System.Serializable]
public class OfficeItemData
{
    [field: SerializeField] public int Id {get; set;} = 0;
}

public enum OfficeItemType
{
    Computer,
}
