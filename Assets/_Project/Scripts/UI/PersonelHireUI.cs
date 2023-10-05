using System.Collections.Generic;
using UnityEngine;

public class PersonelHireUI : MonoBehaviour
{
    [SerializeField] private int currentPersonelHireAmount;

    [SerializeField] private List<PersonelInfoUI> personels;

    [SerializeField] private PersonelSO testPersonelSo;

    void Start()
    {
        Show();
    }

    [ContextMenu("Show Personels")]
    private void Show()
    {
        for (int i = 0; i < personels.Count; i++)
        {
            PersonelInfoUI personelInfo = personels[i];

            if(i >= currentPersonelHireAmount)
            {
                personelInfo.gameObject.SetActive(false);
                continue;
            }
        
            personelInfo.Init(testPersonelSo);
        }
    }

    public PersonelSystem personelSystem;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.LogError("saved");
            personelSystem.Save();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.LogError("cleared");
            personelSystem.Clear();
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.LogError("added");
            personelSystem.Add(testPersonelSo);
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.LogError("loaded");
            personelSystem.Load();
        }
    }
}
