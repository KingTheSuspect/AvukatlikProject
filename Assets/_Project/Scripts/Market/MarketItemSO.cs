using UnityEngine;

public abstract class MarketItemSO : ScriptableObject
{
    [field: SerializeField] public int Price {get; private set;} 

    [field: SerializeField] public Sprite ItemImage {get; private set;}
    [field: SerializeField] public int PrestigeValue {get; private set;}

    public abstract void Buy();
}
