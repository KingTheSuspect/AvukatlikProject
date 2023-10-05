using UnityEngine;
using UnityEngine.UI;
using Lean.Pool;

public class PersonelsUI : MonoBehaviour
{
    [SerializeField] private PersonelInfoUI personelInfoUIPrefab;
    [SerializeField] private PersonelSystem personelSystem;
    [SerializeField] private Transform contentParent;

    [SerializeField] private GameObject panel;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(HandleCloseButton);        
    }

    private void HandleCloseButton()
    {
        panel.SetActive(false);

        PersonelInfoUI[] childInfos = panel.GetComponentsInChildren<PersonelInfoUI>();

        for (int i =  childInfos.Length - 1; i >= 0 ; i--)
        {
            LeanPool.Despawn(childInfos[i]);   
        }
    }

    [ContextMenu("Init")]
    public void Init()
    {
        panel.SetActive(true);
        personelSystem.Load();

        var personels = personelSystem.Personels;

        for (int i = 0; i < personels.Count; i++)
        {
            PersonelInfoUI personelInfo = LeanPool.Spawn(personelInfoUIPrefab, contentParent);
            PersonelSO personelSO = personels[i];
            personelInfo.Init(personelSO);
        }
    }
}
