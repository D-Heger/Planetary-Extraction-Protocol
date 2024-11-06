using System.Collections.Generic;
using UnityEngine;

public class PrefabLoader : MonoBehaviour
{
    public static PrefabLoader Instance { get; private set; }

    [Header("Resource Prefabs")]
    public List<ResourcePrefab> resourcePrefabs;

    [Header("Building Prefabs")]
    public List<BuildingPrefab> buildingPrefabs;

    [Header("Obstacle Prefabs")]
    public List<ObstaclePrefab> obstaclePrefabs;

    private Dictionary<ResourceType, ResourcePrefab> resourcePrefabDict;
    private Dictionary<BuildingType, BuildingPrefab> buildingPrefabDict;
    private Dictionary<ObstacleType, ObstaclePrefab> obstaclePrefabDict;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeDictionaries();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDictionaries()
    {
        resourcePrefabDict = new();
        buildingPrefabDict = new();
        obstaclePrefabDict = new();

        foreach (ResourcePrefab resourcePrefab in resourcePrefabs)
        {
            resourcePrefabDict.Add(resourcePrefab.ResourceType, resourcePrefab);
        }

        foreach (BuildingPrefab buildingPrefab in buildingPrefabs)
        {
            buildingPrefabDict.Add(buildingPrefab.BuildingType, buildingPrefab);
        }

        foreach (ObstaclePrefab obstaclePrefab in obstaclePrefabs)
        {
            obstaclePrefabDict.Add(obstaclePrefab.ObstacleType, obstaclePrefab);
        }
    }

    public ResourcePrefab GetResourcePrefab(ResourceType type)
    {
        if (resourcePrefabDict.ContainsKey(type))
        {
            return resourcePrefabDict[type];
        }
        else
        {
            Debug.LogError($"Resource prefab with type {type} not found.");
            return null;
        }
    }

    public BuildingPrefab GetBuildingPrefab(BuildingType type)
    {
        if (buildingPrefabDict.ContainsKey(type))
        {
            return buildingPrefabDict[type];
        }
        else
        {
            Debug.LogError($"Building prefab with type {type} not found.");
            return null;
        }
    }

    public ObstaclePrefab GetObstaclePrefab(ObstacleType type)
    {
        if (obstaclePrefabDict.ContainsKey(type))
        {
            return obstaclePrefabDict[type];
        }
        else
        {
            Debug.LogError($"Obstacle prefab with type {type} not found.");
            return null;
        }
    }
}
