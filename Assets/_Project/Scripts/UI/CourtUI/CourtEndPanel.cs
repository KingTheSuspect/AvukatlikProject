using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;
using DG.Tweening;
using TMPro;

public class CourtEndPanel : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    [SerializeField] private Sprite starSprite;
    [SerializeField] private Sprite defaultStarSprite;

    [SerializeField] private TMP_Text moneyText;

    [SerializeField] private List<Image> stars;

    public event UnityAction OnContinueButtonClicked;

    private void Awake()
    {
        continueButton.onClick.AddListener(HandleContinueButton);
    }
    private void Start()
    {
        DeInit();
    }

    private void HandleContinueButton()
    {
        OnContinueButtonClicked?.Invoke();
        DeInit();
    }

    private void DeInit()
    {
        gameObject.SetActive(false);
        CourtUI.Instance.Deinit();
    }

    public void Init(int starCount, int moneyAmount)
    {
        gameObject.SetActive(true);
        moneyText.text = $"{moneyAmount}$";
        stars.ForEach(star => star.enabled = false);

        StartCoroutine(Sequence());

        IEnumerator Sequence()
        {
            for (int i = 0; i < stars.Count; i++)
            {
                stars[i].enabled = true;
                if(i < starCount)
                {
                    stars[i].transform.localScale = Vector3.zero;
                    stars[i].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                    stars[i].sprite = starSprite;
                    yield return new WaitForSeconds(0.5f);
                }
                else    
                {
                    stars[i].sprite = defaultStarSprite;
                    yield return null;
                }
            }
        }
    }
}