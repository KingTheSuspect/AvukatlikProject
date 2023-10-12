using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MarketDataBase")]
public class MarketItemDataBase : ScriptableObject
{
    [SerializeField] private List<OfficeMarketItemSO> marketOfficeItems;
    
    public List<OfficeMarketItemSO> OfficeMarketItems => marketOfficeItems;

    //later on market items will be added here
}
