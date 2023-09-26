using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonelInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text ageText;
    [SerializeField] private Image personelImage;

    public void Init(PersonelSO personelSO)
    {
        gameObject.SetActive(true);
        nameText.text = personelSO.PersonelName;
        ageText.text = personelSO.PersonelAge.ToString();
        personelImage.sprite = personelSO.PersonelSprite;
    }
}
