using UnityEngine;
using UnityEngine.UI;

public class ClientInfoUI : MonoBehaviour
{
    [SerializeField] private Image image;
    public void Init(ClientSO clientSO)
    {
        image.sprite = clientSO.ClientSprite;
    }
}
