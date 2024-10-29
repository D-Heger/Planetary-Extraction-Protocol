using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private GridSystem gridSystem;

    public ResourcePrefab ironPrefab;
    public ResourcePrefab copperPrefab;
    public BuildingPrefab minePrefab;
    public ObstaclePrefab wreckagePrefab;

    void Start()
    {
        gridSystem = new GridSystem(
            100,
            100,
            1f,
            new Vector3(0, 0),
            new Dictionary<ResourceType, GameObject>
            {
                { ResourceType.Iron, ironPrefab.prefab },
                { ResourceType.Copper, copperPrefab.prefab },
            },
            new Dictionary<BuildingType, GameObject>
            {
                { BuildingType.Mine, minePrefab.prefab },
            },
            new Dictionary<ObstacleType, GameObject>
            {
                { ObstacleType.Wreckage, wreckagePrefab.prefab },
            }
        );

        gridSystem.GenerateResourcePatch(ResourceType.Iron, 5, 5, 4, 4, 0.35f);
        gridSystem.GenerateResourcePatch(ResourceType.Copper, 10, 10, 3, 3, 0.45f);

        gridSystem.PlaceEntity(5, 5, new BuildingEntity(BuildingType.Mine));

        gridSystem.PlaceEntity(10, 10, new ObstacleEntity(ObstacleType.Wreckage));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { }
    }
}
