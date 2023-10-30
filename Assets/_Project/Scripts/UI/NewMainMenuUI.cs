using UnityEngine;
using UnityEngine.UI;

public class NewMainMenuUI : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private SettingsPanel settingsPanel;
    
    private void Awake()
    {
        settingsButton.onClick.AddListener(HandleSettingsListener);
    }

    private void HandleSettingsListener()
    {
        settingsPanel.Init();
    }
}
