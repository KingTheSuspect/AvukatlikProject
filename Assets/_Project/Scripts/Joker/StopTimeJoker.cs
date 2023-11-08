using UnityEngine;

public class StopTimeJoker : JokerBase
{
    [SerializeField] private float stopTime = 5f;
    protected override void OnClick()
    {
        CourtUI.Instance.CourtTimeManager.StopTimer(stopTime);
    }
}
