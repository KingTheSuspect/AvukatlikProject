using UnityEngine;

public class Managers : MonoBehaviour
{
    public AudioManager AudioManager {get; private set;}
    public EnergyManager EnergyManager {get; private set;}
    public BankManager BankManager {get; private set;}
    public BuildingManager BuildingManager {get; private set;}
    public static Managers Instance {get; private set;}

    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        CacheManagers();
    }

    private void CacheManagers()
    {
        AudioManager = GetComponent<AudioManager>();
        EnergyManager = GetComponent<EnergyManager>();
        BankManager = GetComponent<BankManager>();
        BuildingManager = GetComponent<BuildingManager>();
    }
}
