using System.Collections.Generic;
using UnityEngine;

public class CaseDataBase : ScriptableObject
{
    [SerializeField] private List<CaseSO> cases;

    public bool TryGetCase(int caseID, out CaseSO caseSO)
    {
        caseSO = null;
        CaseSO _case = cases.Find(x => x.ID == caseID);

        if(_case != null)
        {
            caseSO = _case;
            return true;
        }

        return false;
    }
}
