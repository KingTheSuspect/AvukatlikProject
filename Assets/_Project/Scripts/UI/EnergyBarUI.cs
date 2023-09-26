using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarUI : MonoBehaviour
{
    [SerializeField] private EnergyConfig energyConfig;
    [SerializeField] private TMP_Text energyAmountText;
    [SerializeField] private Image fillImage;
    [SerializeField] private int currentEnergy;

    void Start()
    {
        //test
        currentEnergy = energyConfig.MaxEnergyAmount;
        Init(); 
    }

    [ContextMenu("Init")]
    private void Init()
    {
        energyAmountText.text = $"{currentEnergy}/{energyConfig.MaxEnergyAmount}";
        fillImage.fillAmount = (float)currentEnergy / energyConfig.MaxEnergyAmount;

        fillImage.color = Color.Lerp(energyConfig.EmptyBarColor, energyConfig.FullBarColor, (float)currentEnergy / energyConfig.MaxEnergyAmount);
    } 

    void OnValidate()
    {
        Init();
    }
}
