using System.Collections;
using TMPro;
using UnityEngine;

public class CourtTimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float caseTime = 60f;

    private bool isActive = false;
    private void Start()
    {
        CourtUI.OnCaseStarted += HandleCaseStart;
        int minutes = Mathf.FloorToInt(caseTime / 60f);
        int seconds = Mathf.FloorToInt(caseTime - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds); // if wwe will get timer by case then will subs to clientdescpanel case accept
    }

    void Update()
    {
        if(!isActive)
            return;

        caseTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(caseTime / 60f);
        int seconds = Mathf.FloorToInt(caseTime - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(caseTime <= 0)
        {
            Debug.LogError("Case time is over");
            isActive = false;
        }
    }

    public void StopTimer(float stopTime)
    {
        StartCoroutine(StopTimerCoroutine(stopTime));

        IEnumerator StopTimerCoroutine(float stopTime)
        {
            isActive = false;
            yield return new WaitForSeconds(stopTime);
            isActive = true;
        }
    }

    private void HandleCaseStart()
    {
        isActive = true;
    }
    private void OnDestroy()
    {
        CourtUI.OnCaseStarted -= HandleCaseStart;
    }
}
