using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePrefab", menuName = "Grid/ResourcePrefab")]
public class ResourcePrefab : ScriptableObject
{
    public ResourceType resourceType;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "BuildingPrefab", menuName = "Grid/BuildingPrefab")]
public class BuildingPrefab : ScriptableObject
{
    public BuildingType buildingType;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "ObstaclePrefab", menuName = "Grid/ObstaclePrefab")]
public class ObstaclePrefab : ScriptableObject
{
    public ObstacleType obstacleType;
    public GameObject prefab;
}