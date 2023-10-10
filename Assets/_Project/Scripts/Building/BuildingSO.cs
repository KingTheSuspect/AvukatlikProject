using UnityEngine;

[CreateAssetMenu(menuName = "Building")]
public class BuildingSO : ScriptableObject
{
    [field: SerializeField] public int BuyPrice {get; private set;}
    [field: SerializeField] public int UpgradePrice {get; private set;}
    [field: SerializeField] public int Rent {get; private set;}
}
