using UnityEngine;

[CreateAssetMenu(menuName = "Client")]
public class ClientSO : ScriptableObject
{
    [field: SerializeField] public int ID {get; private set;}
    [field: SerializeField] public string ClientName {get; private set;}
    [field: SerializeField] public CaseSO ClientCase {get; private set;}
    [field: SerializeField] public Sprite ClientSprite {get; private set;}
    [field: SerializeField] public bool IsCompleted {get; private set;} = false;
}
