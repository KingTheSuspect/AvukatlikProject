using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Button muteMusicButton;
    [SerializeField] private Button muteSfxButton;

    [SerializeField] private Button closeButton;

    private void Awake()
    {
        muteMusicButton.onClick.AddListener(HandleMuteMusicButton);
        muteSfxButton.onClick.AddListener(HandleMuteSfxButton);
        closeButton.onClick.AddListener(HandleCloseButton);
    }

    private void HandleCloseButton()
    {
        gameObject.SetActive(false);
    }

    private void HandleMuteSfxButton()
    {
        Managers.Instance.AudioManager.ToggleSfx();
    }

    private void HandleMuteMusicButton()
    {
        Managers.Instance.AudioManager.ToggleMusic();
    }

    public void Init()
    {
        gameObject.SetActive(true);
    }
}
