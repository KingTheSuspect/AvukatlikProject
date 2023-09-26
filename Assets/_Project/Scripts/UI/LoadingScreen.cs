using System.Collections;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private TMP_Text loadingText;

    private void Awake()
    {
        panel.SetActive(false);
    }
    
    private void Start() 
    {   
        SceneManagement.OnLoadSceneAsync += HandleLoadSceneAsync;
    }
    private void HandleLoadSceneAsync(AsyncOperation op)
    {
        StartCoroutine(PanelSequence(op)); 

        LoadingTextSequence();
    }

    private void OnDestroy() 
    {
        SceneManagement.OnLoadSceneAsync -= HandleLoadSceneAsync;
    }
    private void LoadingTextSequence()
    {
        string[] texts = new string[3] {"Loading.", "Loading..", "Loading..."};
        StartCoroutine(TextSequence());

        IEnumerator TextSequence()
        {
            int i = 0;
            while(true)
            {
                loadingText.text = texts[i % texts.Length];
                yield return new WaitForSeconds(0.25f);
                i++;
            } 
        }
    }

    private IEnumerator PanelSequence(AsyncOperation op)
    {
        panel.SetActive(true);

        while (!op.isDone)
        {
            yield return null;
        }
        panel.SetActive(false);
    }
}
