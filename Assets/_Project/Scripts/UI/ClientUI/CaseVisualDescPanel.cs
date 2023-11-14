using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CaseVisualDescPanel : MonoBehaviour
{
    [SerializeField] private List<Image> images;

    [SerializeField] private Button acceptButton;

    [SerializeField] private Button cancelButton;

    [SerializeField] private float scaleDuration = 0.75f;

    public static event UnityAction<ClientSO> OnCaseAccepted;

    private void Awake()
    {
        acceptButton.onClick.AddListener(HandleAcceptListener);
        cancelButton.onClick.AddListener(HandleCancelListener);
    }
    private void Start()
    {
        ClientDescPanel.OnCaseContinued += HandleCaseContinued;
        transform.localScale = Vector3.zero;
    }

    private void OnDestroy()
    {
        ClientDescPanel.OnCaseContinued -= HandleCaseContinued;
    }

    private void HandleCaseContinued(ClientSO clientso)
    {
        this.clientSO = clientso;

        OpenPanel();
    }

    private ClientSO clientSO;

    private void OpenPanel()
    {
        transform.localScale = Vector3.one;
        transform.localPosition = new Vector2(0, 1000);

        transform.DOLocalMove(Vector2.zero, 0.75f).SetEase(Ease.OutBack);
    }

    private void HandleAcceptListener()
    {
        ClosePanel(completeAction: ()=> OnCaseAccepted?.Invoke(clientSO));
    }

    private void HandleCancelListener()
    {
        ClosePanel();
    }

    private void ClosePanel(UnityAction completeAction = null)
    {
        transform.DOLocalMove(new Vector2(0, 1000), 0.75f).SetEase(Ease.InBack).OnComplete(()=> {
            completeAction?.Invoke();
            transform.localScale = Vector3.zero;
            });
    }

    private void PlayScaleAnimation(Vector3 target, Ease easeType, UnityAction completeAction)
    {
        transform.DOScale(target, scaleDuration).SetEase(easeType).OnComplete(()=> completeAction?.Invoke());
    }
}
