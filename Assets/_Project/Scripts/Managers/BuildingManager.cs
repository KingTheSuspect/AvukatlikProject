using UnityEngine;
using UnityEngine.Events;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private LayerMask buildingLayer;
    private Camera cam;

    public static event UnityAction<Building, Vector3> OnBuildingSelected;

    private void Awake()
    {
        cam = Camera.main;
    }

    private Building lastSelectedBuilding = null;

    private void Update()
    {
        if(Input.touchCount <= 0)
            return;

        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            Ray ray = cam.ScreenPointToRay(touch.position);
            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, buildingLayer))
            {
                Building building = hit.transform.GetComponent<Building>();

                if(lastSelectedBuilding != null && lastSelectedBuilding == building)
                    return;
                
                Debug.LogError($"Hit: {building.name}", building.gameObject);
                Vector3 screenPosition = cam.WorldToScreenPoint(building.transform.position);

                OnBuildingSelected?.Invoke(building, screenPosition);
                
                lastSelectedBuilding = building;
            }
        }
    }
}
