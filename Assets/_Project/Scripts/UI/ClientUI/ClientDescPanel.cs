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

    [SerializeField] private Button continueButton;
    [SerializeField] private Button backButton;

    [SerializeField] private float scaleDuration = 0.75f;

    private CanvasGroup canvasGroup;

    public static event UnityAction<ClientSO> OnCaseContinued;
    

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        continueButton.onClick.AddListener(HandleContinueListener);    
        backButton.onClick.AddListener(HandleBackListener);    

        ClientInfoUI.OnClientSelected += HandleClientSelected;
        ClosePanel(true);
    }

    private void ClosePanel(bool isInstant = false, UnityAction completeAction = null)
    {
        if(!isInstant)
        {
            PlayScaleAnimation(Vector3.zero, Ease.InBack, ()=> {
                canvasGroup.alpha = 0;
                completeAction?.Invoke();
                });
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
        priceText.text = $"$ {client.ClientCase.CasePrice}";
        clientNameText.text = client.ClientName;

        string caseName = client.ClientCase.GetCaseSubject;
        string desc = caseName + ":" + "\n" + client.ClientCase.GetCaseDescription;
        desc = Helpers.FixTMPOverlap(desc, false);  //to fix the problem of words overlapping each other.
        caseDescText.text = desc;

        clientSO = client;
    }
    private ClientSO clientSO;

    private void HandleBackListener()
    {
        ClosePanel();
    }

    private void HandleContinueListener()
    {
        OnCaseContinued?.Invoke(clientSO); 
        ClosePanel(isInstant: true);
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
