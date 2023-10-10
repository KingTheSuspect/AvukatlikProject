using TMPro;
using UnityEngine;
using DG.Tweening;

public class BuildingInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private float scaleDuration = 0.65f;

    public void Init(BuildingSO buildingSO)
    {
        priceText.text = buildingSO.Price.ToString();

        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;

        transform.DOKill();
        transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
    }
}
