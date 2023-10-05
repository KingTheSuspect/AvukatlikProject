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
        currentEnergy = energyConfig.MaxEnergyAmount; //test
        Init(); 
    }

    [ContextMenu("Init")]
    private void Init()
    {
        energyAmountText.text = $"{currentEnergy}/{energyConfig.MaxEnergyAmount}";
        fillImage.fillAmount = (float)currentEnergy / energyConfig.MaxEnergyAmount;

        fillImage.color = energyConfig.GetColor(currentEnergy);
    } 

    void OnValidate()
    {
        Init();
    }
}
