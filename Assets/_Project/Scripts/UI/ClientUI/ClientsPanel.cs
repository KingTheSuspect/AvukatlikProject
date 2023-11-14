using System;
using Lean.Pool;
using NaughtyAttributes;
using UnityEngine;

public class ClientsPanel : MonoBehaviour
{
    [SerializeField] private Transform contentParent;

    [SerializeField] private ClientInfoUI clientInfoUIPrefab;

    [SerializeField] private ClientDataBase clientDataBase;

    private void Start()
    {
        Init();

        CourtUI.OnCourtUIDeinit += HandleCourtUIDeinit;
    }

    private void OnDestroy()
    {
        CourtUI.OnCourtUIDeinit -= HandleCourtUIDeinit;
    }

    private void HandleCourtUIDeinit()
    {
        this.DelaySeconds(0.25f, Init);
    }

    [Button]
    public void Init()
    {
        DeInit();
        var clients = clientDataBase.GetUncompletedClients();

        foreach (ClientSO client in clients)
        {
            LeanPool.Spawn(clientInfoUIPrefab, contentParent).Init(client);
        }
    }

    [Button]
    public void DeInit()
    {
        for (int i = contentParent.childCount - 1; i >= 0 ; i--)
        {
            LeanPool.Despawn(contentParent.GetChild(i));
        }
    }
}
