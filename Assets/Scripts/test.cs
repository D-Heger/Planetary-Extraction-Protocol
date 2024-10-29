using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private GridSystem gridSystem;

    void Start()
    {
        gridSystem = new GridSystem(
            100,
            100,
            1f,
            new Vector3(0, 0),
            new Dictionary<ResourceType, GameObject>
            {
                { ResourceType.Iron, GetPrefab("IronPrefab") },
                { ResourceType.Copper, GetPrefab("CopperPrefab") },
            },
            new Dictionary<BuildingType, GameObject>
            {
                { BuildingType.Mine, GetPrefab("MinePrefab") },
            },
            new Dictionary<ObstacleType, GameObject>
            {
                { ObstacleType.Wreckage, GetPrefab("WreckagePrefab") },
            }
        );

        gridSystem.GenerateResourcePatch(ResourceType.Iron, 5, 5, 4, 4, 0.35f);
        gridSystem.GenerateResourcePatch(ResourceType.Copper, 10, 10, 3, 3, 0.45f);

        gridSystem.PlaceEntity(5, 5, new BuildingEntity(BuildingType.Mine));

        gridSystem.PlaceEntity(10, 10, new ObstacleEntity(ObstacleType.Wreckage));
    }

    private GameObject GetPrefab(string name)
    {
        return Resources.Load<GameObject>($"Prefabs/{name}");
    }
}
