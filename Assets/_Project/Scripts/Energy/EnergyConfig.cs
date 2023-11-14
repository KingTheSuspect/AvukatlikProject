using System;
using UnityEngine;

//removed create asset menu because need only one config
public class EnergyConfig : ScriptableObject
{
    [SerializeField] private Color fullBarColor = Color.green; 
    [SerializeField] private Color halfBarColor = Color.yellow; 
    [SerializeField] private Color emptyBarColor = Color.red;
    
    [SerializeField] private int maxEnergyAmount = 30;
    [SerializeField] private int energyLoseEachCase = 5;

    [Tooltip("In x seconds will recover 1 energy"), SerializeField] private float energyRecoverTime = 30f;

    public float EnergyRecoverTime => energyRecoverTime;
    public int MaxEnergyAmount => maxEnergyAmount;
    public int EnergyLoseEachCase => energyLoseEachCase;

    public Color GetColor(int currentEnergy)
    {
        float percentage = (currentEnergy / (float)maxEnergyAmount) * 100;

        if(percentage <= 33)
        {
            return emptyBarColor;
        }
        else if (percentage > 33 && percentage < 66)
        {
            return halfBarColor;
        }
        else
            return fullBarColor;
    }
}
