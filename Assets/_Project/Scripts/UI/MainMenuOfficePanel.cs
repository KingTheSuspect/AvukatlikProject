using UnityEngine;
using UnityEngine.UI;

public class MainMenuOfficePanel : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button upgradeButtonInactive;
    [SerializeField] private Button lawyerButton;
    [SerializeField] private Button lawyerButtonInactive;

    [SerializeField] private LawyerPanel lawyerPanel;
    [SerializeField] private GameObject upgradePanel;

    private void Awake()
    {
        upgradeButtonInactive.onClick.AddListener(HandleUpgradeInactiveButton);
        lawyerButtonInactive.onClick.AddListener(HandleLawyerInactiveButton);
    }

    private void Start()
    {
        lawyerPanel.Init();
    }

    private void HandleLawyerInactiveButton()
    {
        lawyerButton.gameObject.SetActive(true);
        lawyerButtonInactive.gameObject.SetActive(false);
        upgradeButton.gameObject.SetActive(false);
        upgradeButtonInactive.gameObject.SetActive(true);

        lawyerPanel.gameObject.SetActive(true);
        upgradePanel.gameObject.SetActive(false);

        lawyerPanel.Init();
    }
    private void HandleUpgradeInactiveButton()
    {
        lawyerButton.gameObject.SetActive(false);
        lawyerButtonInactive.gameObject.SetActive(true);
        upgradeButton.gameObject.SetActive(true);
        upgradeButtonInactive.gameObject.SetActive(false);
        
        upgradePanel.gameObject.SetActive(true);
        lawyerPanel.gameObject.SetActive(false);
        lawyerPanel.DeInit();
    }
}
