using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalftoHalfJoker : JokerBase
{
    override protected void OnClick()
    {
        if(CourtUI.Instance.IsLawyerTurn == false)
            return;

        base.OnClick();
        
        List<CourtAnswerUI> answers = CourtUI.Instance.GetAnswers();

        int removedAnswers = 0;

        switch(answers.Count)
        {
            case 3://for now it's the same as 3 because in our active case theres only 3 answers when we have 4 answers we will get the answers if is active
                for(int i = 0; i < answers.Count; i++)
                {
                    if(answers[i].IsTrueAnswer == false)
                    {
                        answers[i].Hide();
                        break;
                    }
                }

                break;

            case 4:
                for(int i = 0; i < answers.Count; i++)
                {
                    if(answers[i].IsTrueAnswer == false)
                    {
                        answers[i].Hide();
                        removedAnswers++;
                        if(removedAnswers == 2)
                            break;
                    }
                }
                
                break;

            case 5:
                    for(int i = 0; i < answers.Count; i++)
                    {
                        if(answers[i].IsTrueAnswer == false)
                        {
                            answers[i].Hide();
                            removedAnswers++;
                            if(removedAnswers == 2)
                                break;
                        }
                    }

                break;
        }
    }
    
}
