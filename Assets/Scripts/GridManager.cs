using UnityEngine;

public class GridManager : MonoBehaviour
{
    public bool debugMode = false;
    public static GridManager Instance;
    private GridSystem gridSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        var assetLoader = AssetLoader.Instance;

        gridSystem = new GridSystem(100, 100, 1f, new Vector3(0, 0));

        gridSystem.GenerateResourcePatch(
            assetLoader.GetResourceScriptableObject(ResourceType.Iron),
            5,
            5,
            4,
            4,
            0.35f
        );
        gridSystem.GenerateResourcePatch(
            assetLoader.GetResourceScriptableObject(ResourceType.Copper),
            10,
            10,
            3,
            3,
            0.45f
        );

        gridSystem.PlaceBuilding(assetLoader.GetBuildingScriptableObject(BuildingType.Mine), 5, 5);
        gridSystem.PlaceBuilding(assetLoader.GetBuildingScriptableObject(BuildingType.Belt), 4, 5);
        gridSystem.PlaceBuilding(assetLoader.GetBuildingScriptableObject(BuildingType.Belt), 3, 5);
        gridSystem.PlaceBuilding(assetLoader.GetBuildingScriptableObject(BuildingType.Smelter), 2, 5);

        gridSystem.PlaceObstacle(assetLoader.GetObstacleScriptableObject(ObstacleType.Wreckage), 10, 10);
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
