using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "MarketItem/Office")]
public class OfficeMarketItemSO : MarketItemSO
{
    [field: SerializeField] public OfficeItemType OfficeItemType {get; private set;}
    [field: SerializeField] public int ID {get; private set;}

    [Button]
    public override void Buy()
    {
        if(Office.CurrentOffice.TryGetOfficeItem(OfficeItemType, out OfficeItem item))
        {
            item.SetID(ID);
        }
    }
}


