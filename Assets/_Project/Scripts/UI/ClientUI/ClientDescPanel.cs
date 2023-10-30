using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClientDescPanel : MonoBehaviour
{
    [SerializeField] private Image clientImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI clientNameText;
    [SerializeField] private TextMeshProUGUI caseDescText;

    [SerializeField] private Button acceptButton;
    [SerializeField] private Button cancelButton;

    [SerializeField] private float scaleDuration = 0.75f;

    private CanvasGroup canvasGroup;

    private static event UnityAction OnCaseAccepted;
    

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        acceptButton.onClick.AddListener(HandleAcceptListener);    
        cancelButton.onClick.AddListener(HandleCancelListener);    

        ClientInfoUI.OnClientSelected += HandleClientSelected;
        ClosePanel(true);
    }

    private void ClosePanel(bool isInstant = false)
    {
        if(!isInstant)
        {
            PlayScaleAnimation(Vector3.zero, Ease.InBack, ()=> canvasGroup.alpha = 0);
        }
        else
        {
            canvasGroup.alpha = 0;
            transform.localScale = Vector3.zero;
        }
    }

    private void OpenPanel()
    {
        canvasGroup.alpha = 1;
        transform.localScale = Vector3.zero;
        PlayScaleAnimation(Vector3.one, Ease.OutBack, null);
    }

    private void HandleClientSelected(ClientSO client)
    {
        OpenPanel();
        clientImage.sprite = client.ClientSprite;
        priceText.text = client.ClientCase.CasePrice.ToString();
        clientNameText.text = client.ClientName;

        string caseName = client.ClientCase.GetCaseSubject;
        string desc = caseName + ":" + "\n" + client.ClientCase.GetCaseDescription;
        desc = desc.Replace("\r", "");  //to fix the problem of words overlapping each other.
        caseDescText.text = desc;
    }

    private void HandleCancelListener()
    {
        ClosePanel();
    }

    private void HandleAcceptListener()
    {
        ClosePanel();
        OnCaseAccepted?.Invoke(); //TODO clienti clientspanel listesinden silecek
    }

    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        transform.DOScale(target, scaleDuration).SetEase(easeType).OnComplete(()=> completeAction?.Invoke());
    }

    private void OnDestroy()
    {
        ClientInfoUI.OnClientSelected -= HandleClientSelected;
    }
}
