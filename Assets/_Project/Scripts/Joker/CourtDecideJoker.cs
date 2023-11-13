using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CourtDecideJoker : JokerBase
{
    public static event UnityAction<CaseSO> OnDecideJokerClicked;

    protected override void OnClick()
    {
        base.OnClick();

        OnDecideJokerClicked?.Invoke(CourtUI.Instance.CurrentClient.ClientCase);    
    }
}
