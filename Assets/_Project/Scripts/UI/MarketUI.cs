using System;
using System.Collections.Generic;
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
    [SerializeField] private MarketItemDataBase marketItemDataBase;
    [SerializeField] private float scaleDuration = 0.65f;
    [SerializeField] private Button marketButton;
    [SerializeField] private Button closeButton;

    private List<MarketItemUI> marketItems = new();

    private void Awake()
    {
        marketButton.onClick.AddListener(HandleMarketButton);
        marketButton.onClick.AddListener(HandleCloseButton);
        marketPanel.gameObject.SetActive(false);
    }

    private void HandleCloseButton()
    {
        for (int i = marketItems.Count - 1; i >= 0 ; i--)
        {
            LeanPool.Despawn(marketItems[i]);
        }
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
        List<OfficeItem> officeItems = Office.CurrentOffice.OfficeItems;
        List<OfficeMarketItemSO> database = marketItemDataBase.OfficeMarketItems;

        foreach (OfficeItem officeItem in officeItems)
        {
            var typeItems = database.FindAll(x => x.OfficeItemType == officeItem.OfficeItemType);

            foreach (var typeItem in typeItems)
            {
                if(officeItem.CurrentID < typeItem.ID)
                {
                    var spawnedItem = LeanPool.Spawn(marketItemUIPrefab, contentParent);
                    spawnedItem.Init(typeItem);

                    marketItems.Add(spawnedItem);
                }
            }
        }
    }
    
    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        marketPanel.transform.DOScale(target, scaleDuration).SetEase(easeType).OnUpdate(()=>
        contentParent.anchoredPosition = Vector2.zero).OnComplete(()=> completeAction?.Invoke());
    }
}
