using System;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
    public int X { get; set; }
    public int Y { get; set; }
    private BuildingEntity BuildingEntity;
    public GameObject VisualRepresentation { get; set; }
    private GridEntity EnvEntity;
    public bool IsOccupied => BuildingEntity != null || EnvEntity is ObstacleEntity;

    public GridEntity GetEnvEntity() {
        return EnvEntity;
    }

    public BuildingEntity GetBuildingEntity() {
        return BuildingEntity;
    }

    public void SetEntity(GridEntity entity) {

        if(entity is BuildingEntity entity1) {
            BuildingEntity = entity1;
            return;
        }

        EnvEntity = entity;
    }

    public void DeleteEntity(GridEntity gridEntity) {

        if (gridEntity is BuildingEntity) {
            BuildingEntity = null;
        }
        
        EnvEntity = null;
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
