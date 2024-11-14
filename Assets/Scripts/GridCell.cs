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

    public GridEntity GetResourceEntity() {
        return _resourceEntity;
    }

    public GridEntity GetObstacleEntity() {
        return _obstacleEntity;
    }

    public BuildingEntity GetBuildingEntity() {
        return _buildingEntity;
    }

    public void SetEntity<T>(T entity) 
    {
        if (_obstacleEntity != null) {
            return;
        }

        if(entity is BuildingEntity entity1) {
            if(entity1.BuildingScriptableObject.BuildingType == BuildingType.Mine && _resourceEntity == null) {
                return;
            }

            _buildingEntity = entity1;
            return;
        }

        if(entity is ResourceEntity resourceEntity) {
            _resourceEntity = resourceEntity;
        }
    }

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
    }


    public GridEntity GetTopEntity()
    {
        if (BuildingEntity != null) {
            return BuildingEntity;
        } 

        if (EnvEntity != null) {
            return EnvEntity;
        }
        
        return null;
    }
}
