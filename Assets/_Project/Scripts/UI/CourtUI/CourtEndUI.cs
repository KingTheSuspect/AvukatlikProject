using NaughtyAttributes;
using UnityEngine;

public class CourtEndUI : MonoBehaviour
{
    [SerializeField] private CourtEndPanel winPanel;
    [SerializeField] private CourtEndPanel losePanel;

    [SerializeField] private ClientSystem clientSystem;

    private void Start()
    {
        CourtUI.OnCaseCompleted += HandleCaseComplete;
    }

    private void OnDestroy()
    {
        CourtUI.OnCaseCompleted -= HandleCaseComplete;
    }

    private void HandleCaseComplete(CaseSO caseSO)
    {
        int starCount = CourtUI.CurrentTrueAnswerCount;
        if(starCount >= 4)
            starCount = 3;

        bool isWin = starCount >= 2;
        
        Init(isWin, starCount, caseSO.CaseIncome);
    }

    public void Init(bool isWin, int starCount, int moneyAmount)
    {
        if(isWin)
            winPanel.Init(starCount, moneyAmount);
        else
            losePanel.Init(starCount, moneyAmount);

        if(!isWin)
            return;

        winPanel.OnContinueButtonClicked += HandleContinue;

        void HandleContinue()
        {
            clientSystem.Add(CourtUI.Instance.CurrentClient);
            winPanel.OnContinueButtonClicked -= HandleContinue;
        }
    }


    // Test
    [Button]
    public void TestWin()
    {
        Init(true, 3, 100);
    }

    [Button]
    public void TestLose()
    {
        Init(false, 2, 100);
    }
}
