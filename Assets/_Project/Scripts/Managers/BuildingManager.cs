using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private LayerMask buildingLayer;

    [SerializeField] private List<Building> buildings;

    private Camera cam;

    public static event UnityAction<Building, Vector3> OnBuildingSelected;

    private List<Building> activeBuildings = new();

    private IDataService dataService = new JsonDataService();

    private List<int> buildingID = new();

    private Building lastSelectedBuilding = null;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        Load();
    }

    private void Save()
    {
        foreach (var item in activeBuildings)
        {
            buildingID.Add(item.GetInstanceID());
        }

        dataService.SaveData("Buildings.save", buildingID, true);
    }

    public void Add(Building building)
    {
        if(activeBuildings.Contains(building))
            return;
        
        activeBuildings.Add(building);
    }

    private void Load()
    {
        activeBuildings = new();
        List<int> loadedBuildings = dataService.LoadData<List<int>>("Buildings.save", true);
        foreach (var item in loadedBuildings)
        {
            foreach (var building in buildings)
            {
                if(building.GetInstanceID() == item)
                {
                    activeBuildings.Add(building);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.touchCount <= 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        Ray ray = cam.ScreenPointToRay(touch.position);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, buildingLayer))
            return;

        Building building = hit.transform.GetComponent<Building>();

        if (lastSelectedBuilding != null && lastSelectedBuilding == building)
            return;

        Debug.LogError($"Hit: {building.name}", building.gameObject);
        Vector3 screenPosition = cam.WorldToScreenPoint(building.transform.position);

        OnBuildingSelected?.Invoke(building, screenPosition);
        building.Buy();

        lastSelectedBuilding = building;
    }

    private void OnDisable()
    {
        Save();
    }
}
