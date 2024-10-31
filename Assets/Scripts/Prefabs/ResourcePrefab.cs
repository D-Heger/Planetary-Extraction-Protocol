using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePrefab", menuName = "Grid/ResourcePrefab")]
public class ResourcePrefab : ScriptableObject
{
    public ResourceType ResourceType;
    public GameObject Prefab;
}