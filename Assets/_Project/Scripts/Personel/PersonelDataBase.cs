using System.Collections.Generic;
using UnityEngine;

// there will be only one database so i removed createassetmenu after i created so
public class PersonelDataBase : ScriptableObject
{
    [SerializeField] private List<PersonelSO> personels;

    public bool TryGetPersonel(int personelId, out PersonelSO personelSO)
    {
        personelSO = null;
        PersonelSO personel = personels.Find(x => x.ID == personelId);

        if(personel != null)
        {
            personelSO = personel;
            return true;
        }

        return false;
    }
}
