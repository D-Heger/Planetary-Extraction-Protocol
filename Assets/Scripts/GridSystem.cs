using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private GridCell[,] gridCells;
    private Dictionary<ResourceType, GameObject> resourcePrefabs;
    private Dictionary<BuildingType, GameObject> buildingPrefabs;
    private Dictionary<ObstacleType, GameObject> obstaclePrefabs;

    public GridSystem(
        int width,
        int height,
        float cellSize,
        Vector3 originPosition,
        Dictionary<ResourceType, GameObject> resourcePrefabs,
        Dictionary<BuildingType, GameObject> buildingPrefabs,
        Dictionary<ObstacleType, GameObject> obstaclePrefabs
    )
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.resourcePrefabs = resourcePrefabs;
        this.buildingPrefabs = buildingPrefabs;
        this.obstaclePrefabs = obstaclePrefabs;
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

    public int Width()
    {
        return width;
    }

    public int Height()
    {
        return height;
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

    public bool PlaceEntity(int x, int y, GridEntity entity)
    {
        if (IsValidGridPosition(x, y) && !gridCells[x, y].IsOccupied)
        {
            gridCells[x, y].SetEntity(entity);
            CreateVisualRepresentation(x, y);
            return true;
        }
        return false;
    }

    public bool PlaceEntity(Vector3 worldPosition, GridEntity entity)
    {
        int x,
            y;
        GetXY(worldPosition, out x, out y);
        return PlaceEntity(x, y, entity);
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

    private void CreateVisualRepresentation(int x, int y)
    {
        GridEntity topEntity = gridCells[x, y].GetTopEntity();
        GameObject prefab = GetPrefabForEntity(topEntity);
        GameObject gridRepresentation = gridCells[x, y].VisualRepresentation;

        if (prefab != null)
        {
            Vector3 position = GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f;
            GameObject visual = GameObject.Instantiate(prefab, position, Quaternion.identity);

            if (gridRepresentation != null)
            {
                GameObject.Destroy(gridRepresentation);
            }

            // Set the visual to be the correct size
            visual.transform.localScale = new Vector3(cellSize, cellSize, 1f);

            // Adjust the pivot point for better alignment (assuming the pivot is centered)
            visual.transform.position = position;

            gridCells[x, y].VisualRepresentation = visual;
        }
    }

    private GameObject GetPrefabForEntity(GridEntity entity)
    {
        switch (entity.EntityType)
        {
            case EntityType.Resource
                when entity is ResourceEntity resourceEntity
                    && resourceEntity.ResourceType != ResourceType.None:
                resourcePrefabs.TryGetValue(resourceEntity.ResourceType, out var resourcePrefab);
                return resourcePrefab;

            case EntityType.Building
                when entity is BuildingEntity buildingEntity
                    && buildingEntity.BuildingType != BuildingType.None:
                buildingPrefabs.TryGetValue(buildingEntity.BuildingType, out var buildingPrefab);
                return buildingPrefab;

            case EntityType.Obstacle
                when entity is ObstacleEntity obstacleEntity
                    && obstacleEntity.ObstacleType != ObstacleType.None:
                obstaclePrefabs.TryGetValue(obstacleEntity.ObstacleType, out var obstaclePrefab);
                return obstaclePrefab;

            default:
                return null;
        }
    }

    public void PlaceBuilding(BuildingPrefab prefab, int x, int y)
    {
        Debug.Log("Placing building at " + x + ", " + y);
        PlaceEntity(x, y, new BuildingEntity(prefab.BuildingType, prefab.CraftingSpeed));
    }

    public void PlaceObstacle(ObstaclePrefab prefab, int x, int y)
    {
        Debug.Log("Placing obstacle at " + x + ", " + y);
        PlaceEntity(x, y, new ObstacleEntity(prefab.ObstacleType));
    }

    public void PlaceResource(ResourcePrefab prefab, int x, int y, int richness)
    {
        Debug.Log("Placing resource at " + x + ", " + y);
        PlaceEntity(x, y, new ResourceEntity(prefab.ResourceType, richness));
    }

    /// <summary>
    /// Example Method.
    /// <br />
    /// Generates a patch of resources on the grid.
    /// </summary>
    /// <param name="resourcePrefab"></param>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="patchWidth"></param>
    /// <param name="patchHeight"></param>
    public void GenerateResourcePatch(
        ResourcePrefab resourcePrefab,
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
