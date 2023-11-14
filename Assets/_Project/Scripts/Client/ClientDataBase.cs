using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class ClientDataBase : ScriptableObject
{
    [SerializeField, Expandable] private List<ClientSO> clients;

    [SerializeField] private ClientSystem clientSystem;

    public List<ClientSO> GetUncompletedClients()
    {
        clientSystem.Load();
        
        return clients.Where(x => !clientSystem.CompletedClients.Contains(x)).ToList();
    }

    public bool TryGetPersonel(int personelId, out ClientSO clientSO)
    {
        clientSO = null;
        ClientSO client = clients.Find(x => x.ID == personelId);

        if(client != null)
        {
            clientSO = client;
            return true;
        }

        return false;
    }

    public List<ClientSO> GetPersonelByIDs(List<int> ids)
    {
        List<ClientSO> _clients = new();

        foreach (var id in ids)
        {
            if(TryGetPersonel(id, out ClientSO clientSO))
            {
                _clients.Add(clientSO);
            }
        }

        return _clients;
    }
}
