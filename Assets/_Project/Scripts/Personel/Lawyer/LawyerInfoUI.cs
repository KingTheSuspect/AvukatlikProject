using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LawyerInfoUI : MonoBehaviour
{
    [SerializeField] private Image lawyerImage;
    [SerializeField] private TMP_Text lawyerNameText;

    [SerializeField] private TMP_Text lawyerTitleText;

    [SerializeField] private Button buyButton;

    private void Awake()
    {
        buyButton.onClick.AddListener(HandleBuyButton);
    }

    public void Init(LawyerSO lawyerSO)
    {
        lawyerImage.sprite = lawyerSO.PersonelSprite;
        lawyerNameText.text = lawyerSO.PersonelName;
        lawyerTitleText.text =  lawyerSO.LawyerTitle;
    }
    private void HandleBuyButton()
    {

    }
}
