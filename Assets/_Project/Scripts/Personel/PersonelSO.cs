using UnityEngine;

[CreateAssetMenu(menuName = "Personel", fileName = "NewPersonel")]
public class PersonelSO : ScriptableObject
{
    [field: SerializeField] public string PersonelName { get; private set;}
    [field: SerializeField] public int PersonelAge { get; private set;}
    [field: SerializeField] public Sprite PersonelSprite { get; private set;}

   [field: SerializeField]  public int ID {get; set;}
}
