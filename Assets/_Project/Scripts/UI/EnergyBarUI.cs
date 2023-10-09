using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarUI : MonoBehaviour
{
    [SerializeField] private EnergyConfig energyConfig;
    [SerializeField] private TMP_Text energyAmountText;
    [SerializeField] private Image fillImage;

    private void Start()
    {
        DataManager.OnEnergyUpdate += UpdateUI;
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        energyAmountText.text = $"{DataManager.Energy}/{energyConfig.MaxEnergyAmount}";
        fillImage.fillAmount = (float)DataManager.Energy / energyConfig.MaxEnergyAmount;

        fillImage.color = energyConfig.GetColor(DataManager.Energy);
    } 

    private void OnDestroy()
    {
        DataManager.OnEnergyUpdate -= UpdateUI;
    }
}
