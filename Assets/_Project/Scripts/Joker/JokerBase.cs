using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class JokerBase : MonoBehaviour
{
    [SerializeField] private string jokerName;
    [SerializeField] private Sprite jokerSprite;

    [SerializeField] private Image image;

    protected Button button;

    public float GetJokerCooldown()
    {
        switch(CourtUI.Instance.CurrentClient.ClientCase.CaseType)
        {
            case CaseType.Easy:
                return 10f;
            case CaseType.Medium:
                return 15f;
            case CaseType.Hard:
                return 20f;
            default:
                return 15f;
        }
    }

    private void Awake()
    {
        button = GetComponent<Button>();

        image.sprite = jokerSprite;

        button.onClick.AddListener(OnClick);
    }

    protected virtual void OnClick()
    {
        button.interactable = false;

        StartCoroutine(Cooldown());

        IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(GetJokerCooldown());
            button.interactable = true;
        }
    }

}
