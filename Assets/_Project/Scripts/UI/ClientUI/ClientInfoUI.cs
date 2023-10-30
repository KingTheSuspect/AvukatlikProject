using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClientInfoUI : MonoBehaviour
{
    [SerializeField] private Image image;

    private Button button;

    private ClientSO clientSO;

    public static event UnityAction<ClientSO> OnClientSelected;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(HandleButtonListener);
    }

    private void HandleButtonListener()
    {
        if(clientSO == null)
        {
            Debug.LogError("client so is null");
            return;
        }

        OnClientSelected?.Invoke(clientSO);
    }

    public void Init(ClientSO clientSO)
    {
        this.clientSO = clientSO;
        image.sprite = clientSO.ClientSprite;
    }
}
