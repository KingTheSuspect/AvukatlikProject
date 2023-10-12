using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    [SerializeField] private List<OfficeItem> officeItems;

    [SerializeField] private string savePath;

    public string SavePath => savePath;

    public List<OfficeItem> OfficeItems => officeItems;

    public static Office CurrentOffice {get; private set;}

    private void Awake()
    {
        foreach (var item in officeItems)
        {
            item.Init(this);
        }

        CurrentOffice = this;
    }

    //will call from market to set id of office item
    public bool TryGetOfficeItem(OfficeItemType officeItemType, out OfficeItem officeItem)
    {
        officeItem = null;

        foreach (OfficeItem item in officeItems)
        {
            if(item.OfficeItemType == officeItemType)
            {
                officeItem = item;
                return true;
            }    
        }

        return false;
    }
}