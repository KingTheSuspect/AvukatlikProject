using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu(menuName = "PersonelSystem")]
public class PersonelSystem : ScriptableObject
{
    public string savePath;
    [SerializeField] private PersonelDataBase personelDataBase;
    [SerializeField] private List<PersonelSO> personelList;

    public void Add(PersonelSO personelSO)
    {
        if(personelList.Contains(personelSO))
            return;

        personelList.Add(personelSO); 
    }
    public void Remove(PersonelSO personelSO)
    {
        if(!personelList.Contains(personelSO))
            return;

        personelList.Remove(personelSO);
    }

    private List<int> personelIds = new();

    public void Clear()
    {
        personelList.Clear();
    }
    public void Save()
    {
        personelIds.Clear();
        foreach (var item in personelList)
            personelIds.Add(item.ID);
        
        string saveData = JsonUtility.ToJson(personelIds, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        personelList.Clear();

        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), personelIds);

            foreach (int personelID in personelIds)
            {
                if(personelDataBase.TryGetPersonel(personelID, out PersonelSO personel))
                    personelList.Add(personel);

            }

            file.Close();
        }
    }
}
