using System;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private EnergyConfig energyConfig;
    public EnergyConfig EnergyConfig => energyConfig;

    private DateTime energySpendDateTime; 
    private float timePassed;

    private bool IsFullEnergy => DataManager.Energy >= energyConfig.MaxEnergyAmount;

    private void Start()
    {
        LoadDate();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SpendEnergy(1);

        if(IsFullEnergy)
            return;
        
        RecoverEnergyWithTime();
    }

    private void SpendEnergyForCase()
    {
        SpendEnergy(energyConfig.EnergyLoseEachCase);
    }

    public void SpendEnergy(int spendAmount)
    {
        int energy = DataManager.Energy;
        if(energy <= 0)
        {
            return;
        }
        if((energy -= spendAmount) < 0)
            return;

        if (energy < energyConfig.MaxEnergyAmount)
        {
            DataManager.Energy -= spendAmount;
        }

        SaveDate();
    }

    public void RecoverEnergyWithTime()
    {
        timePassed = (float)(DateTime.Now - energySpendDateTime).TotalSeconds;

        if (timePassed >= energyConfig.EnergyRecoverTime)
        {
            DataManager.Energy++;
            energySpendDateTime = DateTime.Now;

            if (DataManager.Energy >= energyConfig.MaxEnergyAmount)
            {
                DataManager.Energy = energyConfig.MaxEnergyAmount;
            }
        }
    }

    public void RecoverEnergyOnGameLoad()
    {
        timePassed = (float)(DateTime.Now - energySpendDateTime).TotalSeconds;

        if (timePassed >= energyConfig.EnergyRecoverTime)
        {
            DataManager.Energy = DataManager.Energy >= energyConfig.MaxEnergyAmount ? 
            energyConfig.MaxEnergyAmount : 
            DataManager.Energy += Mathf.RoundToInt(timePassed / energyConfig.EnergyRecoverTime);
        }

        energySpendDateTime = DateTime.Now;
    }

    public void SaveDate()
    {
        PlayerPrefs.SetString(PlayerPrefsKeys.EnergySpendTimeKey, energySpendDateTime.ToString());
    }

    public void LoadDate()
    {
        string date = PlayerPrefs.GetString(PlayerPrefsKeys.EnergySpendTimeKey, string.Empty); 
        if (date == string.Empty)
        {
            DataManager.Energy = energyConfig.MaxEnergyAmount;
        }
        else if (date != null)
        {
            energySpendDateTime = Convert.ToDateTime(date);
            RecoverEnergyOnGameLoad();
        }
    }

    private void OnApplicationQuit()
    {
        SaveDate();
    }
}
