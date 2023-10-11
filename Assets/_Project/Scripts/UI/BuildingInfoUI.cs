using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuildingInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private float scaleDuration = 0.65f;

    [SerializeField] private List<Image> personelImages; //todo might change later not just image 

    public void Init(Building building)
    {
        priceText.text = building.BuildingSO.BuyPrice.ToString();
        //TODO show building.GetPersonels

        var personels = building.GetPersonels();

        personelImages.ForEach(x=> x.gameObject.SetActive(false));

        for (int i = 0; i < personels.Count; i++)
        {
            PersonelSO personel = personels[i];
            Image personelImage = personelImages[i];

            personelImage.gameObject.SetActive(true);
            personelImage.sprite = personel.PersonelSprite;
        }
        
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;

        transform.DOKill();
        transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
    }
}
