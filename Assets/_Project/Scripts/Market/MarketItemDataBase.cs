using System.Collections.Generic;
using UnityEngine;

public class MarketItemDataBase : ScriptableObject
{
    [SerializeField] private List<OfficeMarketItemSO> marketOfficeItems;
    
    public List<OfficeMarketItemSO> OfficeMarketItems => marketOfficeItems;

    //later on market items will be added here
}
