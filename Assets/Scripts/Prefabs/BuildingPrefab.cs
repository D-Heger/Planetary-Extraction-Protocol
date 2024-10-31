using UnityEngine;

[CreateAssetMenu(fileName = "BuildingPrefab", menuName = "Grid/BuildingPrefab")]
public class BuildingPrefab : ScriptableObject
{
    public BuildingType BuildingType;
    public GameObject Prefab;
    public float CraftingSpeed = 1;
}