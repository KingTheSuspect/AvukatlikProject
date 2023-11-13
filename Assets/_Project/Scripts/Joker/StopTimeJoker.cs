using UnityEngine;

public class StopTimeJoker : JokerBase
{
    protected override void OnClick()
    {
        if(CourtUI.Instance.IsLawyerTurn == false)
            return;

        base.OnClick();       
        CourtUI.Instance.CourtTimeManager.StopTimer();
    }
}
