using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button settingsButton;

    [SerializeField] private Button playButton;

    [SerializeField] private SettingsPanel settingsPanel;

    private void Awake()
    {
        settingsButton.onClick.AddListener(HandleSettingsButton);
        playButton.onClick.AddListener(HandlePlayButton);
        settingsPanel.gameObject.SetActive(false);
    }

    private void HandlePlayButton()
    {
        SceneManagement.Instance.LoadSceneAsync("GameScene"); // test scene
    }

    private void HandleSettingsButton()
    {
        settingsPanel.Init();
    }
}
