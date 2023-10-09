using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Button muteMusicButton;
    [SerializeField] private Button muteSfxButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private float scaleDuration = 0.75f;

    private void Awake()
    {
        muteMusicButton.onClick.AddListener(HandleMuteMusicButton);
        muteSfxButton.onClick.AddListener(HandleMuteSfxButton);
        closeButton.onClick.AddListener(HandleCloseButton);
    }

    private void HandleCloseButton()
    {
        void CompleteAction()
        {
            gameObject.SetActive(false);
        }

        transform.localScale = Vector3.one;
        PlayScaleAnimation(Vector3.zero, Ease.InBack, CompleteAction);
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
        transform.localScale = Vector3.zero;
        PlayScaleAnimation(Vector3.one, Ease.OutBack, null);
    }

    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        transform.DOScale(target, scaleDuration).SetEase(easeType).OnComplete(()=> completeAction?.Invoke());
    }
}
