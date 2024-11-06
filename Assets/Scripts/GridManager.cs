using UnityEngine;

public class GridManager : MonoBehaviour
{
    private GridSystem gridSystem;

    public bool debugMode = false;

    void Start()
    {
        var prefabLoader = PrefabLoader.Instance;

        gridSystem = new GridSystem(100, 100, 1f, new Vector3(0, 0));

        gridSystem.GenerateResourcePatch(
            prefabLoader.GetResourcePrefab(ResourceType.Iron),
            5,
            5,
            4,
            4,
            0.35f
        );
        gridSystem.GenerateResourcePatch(
            prefabLoader.GetResourcePrefab(ResourceType.Copper),
            10,
            10,
            3,
            3,
            0.45f
        );

        gridSystem.PlaceBuilding(prefabLoader.GetBuildingPrefab(BuildingType.Mine), 5, 5);
        gridSystem.PlaceBuilding(prefabLoader.GetBuildingPrefab(BuildingType.Belt), 4, 5);
        gridSystem.PlaceBuilding(prefabLoader.GetBuildingPrefab(BuildingType.Belt), 3, 5);
        gridSystem.PlaceBuilding(prefabLoader.GetBuildingPrefab(BuildingType.Smelter), 2, 5);

        gridSystem.PlaceObstacle(prefabLoader.GetObstaclePrefab(ObstacleType.Wreckage), 10, 10);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (debugMode)
            {
                LogGridEntities();
            }
        }
    }

    public void LogGridEntities()
    {
        Vector3 position = Utils.GetMouseWorldPosition();
        GridCell cell = gridSystem.GetCell((int)position.x, (int)position.y);
        Debug.Log(cell.GetEnvEntity());
        Debug.Log(cell.GetBuildingEntity());
        Debug.Log(cell.VisualRepresentation);
    }

    public GridSystem GetGridSystem()
    {
        return gridSystem;
    }
}
