using UnityEngine;

[CreateAssetMenu(menuName = "Building")]
public class BuildingSO : ScriptableObject
{
    [field: SerializeField] public int Price {get; private set;}
}
