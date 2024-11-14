using System;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public GameObject VisualRepresentation { get; set; }
    public bool IsOccupied => _buildingEntity != null || _obstacleEntity != null;

    private BuildingEntity _buildingEntity;
    private ResourceEntity _resourceEntity;
    private ObstacleEntity _obstacleEntity;

    public ResourceEntity GetResourceEntity()
    {
        return _resourceEntity;
    }

    public ObstacleEntity GetObstacleEntity()
    {
        return _obstacleEntity;
    }

    public BuildingEntity GetBuildingEntity()
    {
        return _buildingEntity;
    }

    public void SetEntity<T>(T entity)
    {
        if (_obstacleEntity != null)
        {
            return;
        }

        if (entity is BuildingEntity entity1)
        {
            if (
                entity1.BuildingScriptableObject.BuildingType == BuildingType.Mine
                && _resourceEntity == null
            )
            {
                return;
            }

            _buildingEntity = entity1;
            return;
        }

        if (entity is ResourceEntity resourceEntity)
        {
            _resourceEntity = resourceEntity;
        }
    }

    public void RemoveEntity<T>(T entity)
    {
        switch (entity)
        {
            case BuildingEntity buildingEntity:
                RemoveBuildingEntity();
                break;
            case ResourceEntity resourceEntity:
                RemoveResourceEntity();
                break;
            case ObstacleEntity obstacleEntity:
                RemoveObstacleEntity();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(entity), entity, null);
        }
    }

    private void RemoveBuildingEntity()
    {
        if (_buildingEntity == null)
        {
            Debug.LogError("Trying to remove building entity from empty cell");
            return;
        }

        Debug.Log($"Removing building entity from cell {X}, {Y}");
        _buildingEntity = null;
    }

    private void RemoveResourceEntity()
    {
        if (_resourceEntity == null)
        {
            Debug.LogError("Trying to remove resource entity from empty cell");
            return;
        }

        Debug.Log($"Removing resource entity from cell {X}, {Y}");
        _resourceEntity = null;
    }

    private void RemoveObstacleEntity()
    {
        if (_obstacleEntity == null)
        {
            Debug.LogError("Trying to remove obstacle entity from empty cell");
            return;
        }

        Debug.Log($"Removing obstacle entity from cell {X}, {Y}");
        _obstacleEntity = null;
    }

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
    }
}
