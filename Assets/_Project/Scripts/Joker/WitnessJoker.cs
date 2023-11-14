
public class WitnessJoker : JokerBase
{
    protected override void OnClick()
    {
        if(CourtUI.Instance.IsLawyerTurn == false)
            return;

        base.OnClick();

        CourtAnswerUI answer = CourtUI.Instance.GetAnswers().Find(x => x.IsTrueAnswer == true);

        answer.HandleButton();
    }
}
