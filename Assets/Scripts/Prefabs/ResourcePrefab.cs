using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePrefab", menuName = "Prefabs/ResourcePrefab")]
public class ResourcePrefab : ScriptableObject
{
    public ResourceType ResourceType;
    public GameObject Prefab;
}