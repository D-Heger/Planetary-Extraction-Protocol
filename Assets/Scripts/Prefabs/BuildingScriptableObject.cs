using UnityEngine;

[CreateAssetMenu(fileName = "BuildingPrefab", menuName = "Prefabs/BuildingPrefab")]
public class BuildingScriptableObject : ScriptableObject
{
    public BuildingType BuildingType;
    public GameObject Prefab;
    public float Speed;
}