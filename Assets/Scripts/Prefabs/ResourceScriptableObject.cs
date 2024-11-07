using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePrefab", menuName = "Prefabs/ResourcePrefab")]
public class ResourceScriptableObject : ScriptableObject
{
    public ResourceType ResourceType;
    public GameObject Prefab;
}