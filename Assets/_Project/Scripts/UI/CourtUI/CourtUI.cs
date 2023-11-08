using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class CourtUI : MonoBehaviour
{
    [SerializeField] private CourtTextUI lawyerTextPrefab;
    [SerializeField] private CourtTextUI judgeTextPrefab;

    [SerializeField] private Transform contentParent;
    [SerializeField] private Transform fakeContentParent;

    [SerializeField] private CaseSO currentCase;

    [SerializeField] private List<CourtAnswerUI> answers;

    [SerializeField] private GameObject panel;

    private int questionIndex = 0;

    [SerializeField] private ScrollRect scrollRect;

    [SerializeField] private Image tempImage; //TEMP

    public static CourtUI Instance;

    private ClientSO currentClient;

    public ClientSO CurrentClient => currentClient;

    public static event UnityAction<CaseSO> OnCaseCompleted;

    public static event UnityAction OnCaseStarted;
    public static event UnityAction OnCourtUIDeinit;

    public static int CurrentTrueAnswerCount = 0;

    public CourtTimeManager CourtTimeManager {get; private set;}

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        panel.gameObject.SetActive(false);
        tempImage.enabled = false;

        CourtTimeManager = GetComponent<CourtTimeManager>();
    }

    private void Start()
    {
        CaseVisualDescPanel.OnCaseAccepted += HandleCaseAccept;   
    }

    private void OnDestroy()
    {
        CaseVisualDescPanel.OnCaseAccepted -= HandleCaseAccept;   
    }

    private void HandleCaseAccept(ClientSO clientSo)
    {
        Init(clientSo);
    }

    private void MoveContent()
    {
        Vector2 position = new Vector2(scrollRect.horizontalNormalizedPosition, 0);
        scrollRect.DONormalizedPos(position, 0.5f);
    }

    public void Deinit()
    {
        panel.gameObject.SetActive(false);
        tempImage.enabled = false;
        OnCourtUIDeinit?.Invoke();

        for (int i = contentParent.childCount - 1; i >= 0 ; i--)
        {
            LeanPool.Despawn(contentParent.GetChild(i));
        }

        scrollRect.normalizedPosition = Vector2.zero;
    }

    public void Init(ClientSO clientSO)
    {
        panel.gameObject.SetActive(true);
        currentClient = clientSO;
        this.currentCase = currentClient.ClientCase;
        CurrentTrueAnswerCount = 0;
        questionIndex = 0;
        tempImage.enabled = true;

        var prefab = LeanPool.Spawn(judgeTextPrefab, fakeContentParent);
        prefab.OnTextComplete += OnTextComplete;
        
        StartCoroutine(StartSequence());

        IEnumerator StartSequence()
        {
            yield return null;
            prefab.Init(currentCase.GetJudgeStartText);
        }

        void OnTextComplete()
        {
            prefab.OnTextComplete -= OnTextComplete;
            AddLawyerText(currentCase.GetCaseDescription);
        }
    }

    public void AddLawyerText(string lawyerText)
    {
        var prefab = LeanPool.Spawn(lawyerTextPrefab, fakeContentParent);
        
        answers.ForEach(x => x.Hide());
        
        prefab.OnTextComplete += OnTextComplete;

        void OnTextComplete()
        {
            prefab.OnTextComplete -= OnTextComplete;

            this.DelaySeconds(1f, AddJudgeText);
        }

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return null;
            prefab.Init(lawyerText);
            yield return null;
            MoveContent();
        }
    } 

    public void SetParent(Transform prefab)
    {
        prefab.transform.SetParent(contentParent);
    }

    [Button]
    public void AddJudgeText()
    {
        if(questionIndex >= currentCase.Questions.Count)
        {
            OnCaseCompleted?.Invoke(currentCase);
            Debug.LogError("no more questions");
            return;
        }

        var prefab = LeanPool.Spawn(judgeTextPrefab, fakeContentParent);
        string question = currentCase.Questions[questionIndex].GetQuestion;

        prefab.OnTextComplete += HandleTextComplete;

        void HandleTextComplete()
        {
            prefab.OnTextComplete -= HandleTextComplete;

            if(questionIndex == 0)
                OnCaseStarted?.Invoke();

            
            InitAnswers();
        }

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return null;
            prefab.Init(question);
            yield return null;
            MoveContent();
        }
        
    }

    private void InitAnswers()
    {
        for (int i = 0; i < answers.Count; i++)
        {
            CourtAnswerUI answer = answers[i];
            answer.Init(currentCase.Questions[questionIndex].GetAnswer(i), currentCase.Questions[questionIndex].IsTrueAnswer(currentCase.Questions[questionIndex].Answers[i]));
        }

        questionIndex++;
    }

}
