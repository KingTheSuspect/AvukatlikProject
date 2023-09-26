using UnityEngine;

[CreateAssetMenu(menuName = "Energy")]
public class EnergyConfig : ScriptableObject
{
    [SerializeField] private Color fullBarColor = Color.green; 
    [SerializeField] private Color emptyBarColor = Color.red;
    
    [SerializeField] private int maxEnergyAmount = 30;

    [SerializeField] private int energyLoseEachCase = 5;

    public int MaxEnergyAmount => maxEnergyAmount;

    public Color FullBarColor => fullBarColor;
    public Color EmptyBarColor => emptyBarColor;
}
