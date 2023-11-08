using UnityEngine;
using UnityEngine.UI;

public abstract class JokerBase : MonoBehaviour
{
    [SerializeField] private string jokerName;
    [SerializeField] private Sprite jokerSprite;

    [SerializeField] private Image image;

    protected Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        image.sprite = jokerSprite;

        button.onClick.AddListener(OnClick);
    }

    protected virtual void OnClick()
    {
        button.interactable = false;
    }

}
