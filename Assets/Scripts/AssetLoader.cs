using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    public static AssetLoader Instance { get; private set; }

    [Header("Resource ScriptableObjects")]
    public List<ResourceScriptableObject> resourceScriptableObjects;

    [Header("Building ScriptableObjects")]
    public List<BuildingScriptableObject> buildingScriptableObjects;

    [Header("Obstacle ScriptableObjects")]
    public List<ObstacleScriptableObject> obstacleScriptableObjects;

    private Dictionary<ResourceType, ResourceScriptableObject> resourceScriptableObjectDict;
    private Dictionary<BuildingType, BuildingScriptableObject> buildingScriptableObjectDict;
    private Dictionary<ObstacleType, ObstacleScriptableObject> obstacleScriptableObjectDict;

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
        resourceScriptableObjectDict = new();
        buildingScriptableObjectDict = new();
        obstacleScriptableObjectDict = new();

        foreach (ResourceScriptableObject resourceScriptableObject in resourceScriptableObjects)
        {
            resourceScriptableObjectDict.Add(resourceScriptableObject.ResourceType, resourceScriptableObject);
        }

        foreach (BuildingScriptableObject buildingScriptableObject in buildingScriptableObjects)
        {
            buildingScriptableObjectDict.Add(buildingScriptableObject.BuildingType, buildingScriptableObject);
        }

        foreach (ObstacleScriptableObject obstacleScriptableObject in obstacleScriptableObjects)
        {
            obstacleScriptableObjectDict.Add(obstacleScriptableObject.ObstacleType, obstacleScriptableObject);
        }
    }

    public ResourceScriptableObject GetResourceScriptableObject(ResourceType type)
    {
        if (resourceScriptableObjectDict.ContainsKey(type))
        {
            return resourceScriptableObjectDict[type];
        }
        else
        {
            Debug.LogError($"Resource prefab with type {type} not found.");
            return null;
        }
    }

    public BuildingScriptableObject GetBuildingScriptableObject(BuildingType type)
    {
        if (buildingScriptableObjectDict.ContainsKey(type))
        {
            return buildingScriptableObjectDict[type];
        }
        else
        {
            Debug.LogError($"Building prefab with type {type} not found.");
            return null;
        }
    }

    public ObstacleScriptableObject GetObstacleScriptableObject(ObstacleType type)
    {
        if (obstacleScriptableObjectDict.ContainsKey(type))
        {
            return obstacleScriptableObjectDict[type];
        }
        else
        {
            Debug.LogError($"Obstacle prefab with type {type} not found.");
            return null;
        }
    }
}
