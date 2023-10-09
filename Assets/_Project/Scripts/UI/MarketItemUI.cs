using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketItemUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button button;

    private MarketItemSO marketItemSO;

    private void Awake()
    {
        button.onClick.AddListener(HandleBuyButton);
    }

    private void HandleBuyButton()
    {
        marketItemSO.Buy();
    }

    public void Init(MarketItemSO marketItemSO)
    {
        itemImage.sprite = marketItemSO.ItemImage;
        priceText.text = marketItemSO.Price.ToString();
        this.marketItemSO = marketItemSO;
    }
}
