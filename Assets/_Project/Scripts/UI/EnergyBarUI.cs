using TMPro;
using UnityEngine;

public class EnergyBarUI : MonoBehaviour
{
    [SerializeField] private EnergyConfig energyConfig;
    [SerializeField] private TMP_Text energyAmountText;

    private void Start()
    {
        DataManager.OnEnergyUpdate += UpdateUI;
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        energyAmountText.text = $"{DataManager.Energy}/{energyConfig.MaxEnergyAmount}";
    } 

    private void OnDestroy()
    {
        DataManager.OnEnergyUpdate -= UpdateUI;
    }
}
