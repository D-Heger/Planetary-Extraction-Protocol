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
                { ironPrefab.ResourceType, ironPrefab.Prefab },
                { copperPrefab.ResourceType, copperPrefab.Prefab },
            },
            new Dictionary<BuildingType, GameObject>
            {
                { minePrefab.BuildingType, minePrefab.Prefab },
            },
            new Dictionary<ObstacleType, GameObject>
            {
                { wreckagePrefab.ObstacleType, wreckagePrefab.Prefab },
            }
        );

        gridSystem.GenerateResourcePatch(ironPrefab, 5, 5, 4, 4, 0.35f);
        gridSystem.GenerateResourcePatch(copperPrefab, 10, 10, 3, 3, 0.45f);

        gridSystem.PlaceBuilding(minePrefab, 5, 5);

        gridSystem.PlaceEntity(10, 10, new ObstacleEntity(ObstacleType.Wreckage));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { }
    }
}
