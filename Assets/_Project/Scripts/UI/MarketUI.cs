using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    [SerializeField] private RectTransform marketPanel;
    [SerializeField] private RectTransform contentParent;
    [SerializeField] private MarketItemUI marketItemUIPrefab;
    [SerializeField] private MarketItemSO marketItemSO;
    [SerializeField] private float scaleDuration = 0.65f;
    [SerializeField] private int testAmount;
    [SerializeField] private Button marketButton;

    private void Awake()
    {
        marketButton.onClick.AddListener(HandleMarketButton);
        marketPanel.gameObject.SetActive(false);
    }

    private void HandleMarketButton()
    {
        Init();
        marketPanel.gameObject.SetActive(true);
        marketPanel.localScale = Vector3.zero;
        PlayScaleAnimation(Vector3.one, Ease.OutBack, null);
    }

    private void Init()
    {
        for (int i = 0; i < testAmount; i++)
        {
            LeanPool.Spawn(marketItemUIPrefab, contentParent).Init(marketItemSO);
        }
    }
    
    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        marketPanel.transform.DOScale(target, scaleDuration).SetEase(easeType).OnUpdate(()=>
        contentParent.anchoredPosition = Vector2.zero).OnComplete(()=> completeAction?.Invoke());
    }
}
