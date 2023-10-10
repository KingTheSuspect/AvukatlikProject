using UnityEngine;
using UnityEngine.Events;

public class Building : MonoBehaviour, IBuyable
{
    [field: SerializeField] public BuildingSO BuildingSO {get; private set;}

    private Camera cam;

    public event UnityAction OnBought; //for later on purposes

    void Awake()
    {
        cam = Camera.main;
    }

    private bool IsBuyable => DataManager.Currency >= BuildingSO.Price;

    public void Buy()
    {
        if(!IsBuyable)
            return;

        OnBought?.Invoke();
    }
}