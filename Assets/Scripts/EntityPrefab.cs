using UnityEngine;

[CreateAssetMenu(fileName = "EntityPrefab", menuName = "Grid/EntityPrefab")]
public class EntityPrefab : ScriptableObject
{
    public ResourceType resourceType;
    public BuildingType buildingType;
    public ObstacleType obstacleType;
    public GameObject prefab;
}