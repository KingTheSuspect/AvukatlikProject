using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building")]
public class BuildingSO : ScriptableObject
{
    [field: SerializeField] public PersonelDataBase PersonelDataBase {get; private set;} //Todo might change to a singleton personelmanager then get the list from there
    [field: SerializeField] public int BuyPrice {get; private set;}
    [field: SerializeField] public int MaxLevel {get; private set;} = 10;
    [field: SerializeField] public List<int> PrestigeByLevels;
    [field: SerializeField] public List<int> MaxPersonelCountByLevels;
    [field: SerializeField] public List<int> RentByLevels;
    [field: SerializeField] public List<int> UpgradePriceByLevels;
}
