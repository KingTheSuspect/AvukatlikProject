using System.Collections.Generic;
using UnityEngine;

public class PersonelHireUI : MonoBehaviour
{
    [SerializeField] private int currentPersonelHireAmount;

    [SerializeField] private List<PersonelInfoUI> personels;

    private void Start()
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
        }
    }
}
