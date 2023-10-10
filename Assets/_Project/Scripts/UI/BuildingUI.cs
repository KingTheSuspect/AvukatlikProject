using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    [SerializeField] private BuildingInfoUI buildingInfoUI;

    private void Awake()
    {
        buildingInfoUI.gameObject.SetActive(false);
    }

    private void Start()
    {
        BuildingManager.OnBuildingSelected += HandleBuildingSelected;        
    }

    private void HandleBuildingSelected(Building building, Vector3 screenPosition)
    {
        if(buildingInfoUI.gameObject.activeInHierarchy)
        {
            buildingInfoUI.gameObject.SetActive(false);
        }

        buildingInfoUI.Init(building.BuildingSO);
        buildingInfoUI.transform.position = screenPosition;
    }

    private void OnDestroy()
    {
        BuildingManager.OnBuildingSelected -= HandleBuildingSelected;
    }
}
