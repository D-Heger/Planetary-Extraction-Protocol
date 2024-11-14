using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private GridCell[,] gridCells;

    public GridSystem(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridCells = new GridCell[width, height];

        // Initialize grid cells
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridCells[x, y] = new GridCell(x, y);
                Debug.DrawLine(
                    GetWorldPosition(x, y),
                    GetWorldPosition(x, y + 1),
                    Color.white,
                    999f
                );
                Debug.DrawLine(
                    GetWorldPosition(x, y),
                    GetWorldPosition(x + 1, y),
                    Color.white,
                    999f
                );
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public bool PlaceEntity<T>(int x, int y, T entity, GameObject prefab)
    {
        if (!IsValidGridPosition(x, y) || gridCells[x, y].IsOccupied)
        {
            return false;
        }

        gridCells[x, y].SetEntity(entity);
        CreateVisualRepresentation(x, y, entity, prefab);
        return true;

    }

    public bool PlaceEntity(Vector3 worldPosition, GridEntity entity, GameObject prefab)
    {
        int x,
            y;
        GetXY(worldPosition, out x, out y);
        return PlaceEntity(x, y, entity, prefab);
    }

    public void RemoveEntity(int x, int y, GridEntity entity)
    {
        if (IsValidGridPosition(x, y))
        {
            if (gridCells[x, y].VisualRepresentation != null)
            {
                GameObject.Destroy(gridCells[x, y].VisualRepresentation);
            }
            gridCells[x, y].DeleteEntity(entity);
        }
    }

    public GridCell GetCell(int x, int y)
    {
        return IsValidGridPosition(x, y) ? gridCells[x, y] : null;
    }

    private bool IsValidGridPosition(int x, int y)
    {
        return x >= 0 && y >= 0 && x < width && y < height;
    }

    private void CreateVisualRepresentation<T>(int x, int y, T entity, GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }

        GameObject gridRepresentation = gridCells[x, y].VisualRepresentation;

        Vector3 position = GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f;
        GameObject visual = GameObject.Instantiate(prefab, position, Quaternion.identity);
        
        if (entity is BuildingEntity) {
            ObjectStorage objectStorage = visual.GetComponent<ObjectStorage>();

            objectStorage.SetObject<T>(entity);
        }

        if (gridRepresentation != null)
        {
            GameObject.Destroy(gridRepresentation);
        }

        visual.transform.localScale = new Vector3(cellSize, cellSize, 1f);
        visual.transform.position = position;

        gridCells[x, y].VisualRepresentation = visual;
    }

    public void PlaceBuilding(BuildingScriptableObject prefab, int x, int y)
    {
        Debug.Log("Placing building at " + x + ", " + y);
        PlaceEntity(
            x,
            y,
            new BuildingEntity(prefab, x, y),
            prefab.Prefab
        );
    }

    public void PlaceObstacle(ObstacleScriptableObject prefab, int x, int y)
    {
        Debug.Log("Placing obstacle at " + x + ", " + y);
        PlaceEntity(x, y, new ObstacleEntity(prefab.ObstacleType), prefab.Prefab);
    }

    public void PlaceResource(ResourceScriptableObject prefab, int x, int y, int richness)
    {
        Debug.Log("Placing resource at " + x + ", " + y);
        PlaceEntity(x, y, new ResourceEntity(prefab.ResourceType, richness), prefab.Prefab);
    }

    public void GenerateResourcePatch(
        ResourceScriptableObject resourcePrefab,
        int startX,
        int startY,
        int patchWidth,
        int patchHeight,
        float richness
    )
    {
        for (int x = startX; x < startX + patchWidth && x < width; x++)
        {
            for (int y = startY; y < startY + patchHeight && y < height; y++)
            {
                if (!gridCells[x, y].IsOccupied)
                {
                    PlaceResource(resourcePrefab, x, y, (int)(richness * 100));
                }
            }
        }
    }
}
