using UnityEngine;

[CreateAssetMenu(fileName = "BuildingPrefab", menuName = "Prefabs/BuildingPrefab")]
public class BuildingPrefab : ScriptableObject
{
    public BuildingType BuildingType;
    public GameObject Prefab;
    public float CraftingSpeed = 1;
}