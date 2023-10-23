using System.Collections.Generic;
using Lean.Pool;
using NaughtyAttributes;
using UnityEngine;

public class ClientsPanel : MonoBehaviour
{
    [SerializeField] private Transform contentParent;

    [SerializeField] private ClientInfoUI clientInfoUIPrefab;

    [SerializeField] private ClientDataBase clientDataBase;

    [SerializeField] private int clientTestValue = 5;

    [SerializeField] private List<ClientSO> clientSOs;



    //this is temp, just for testing

    void Start()
    {
        Init();
    }

    [Button]
    public void Init()
    {
        for (int i = 0; i < clientTestValue; i++)
        {
            ClientSO clientSO = clientSOs[i < clientSOs.Count ? i : clientSOs.Count - 1];
            LeanPool.Spawn(clientInfoUIPrefab, contentParent).Init(clientSO);
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
