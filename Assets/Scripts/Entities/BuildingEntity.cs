using System.Collections.Generic;
using UnityEngine;

public class BuildingEntity : GridEntity
{
    public DirectionType inputDirection = DirectionType.Left;
    public DirectionType outputDirection = DirectionType.Right;
    public List<ResourceEntity> InputStorage = new();
    public List<ResourceEntity> OutputStorage = new();
    public BuildingScriptableObject BuildingScriptableObject;
    public int X;
    public int Y;

    public BuildingEntity(BuildingScriptableObject buildingScriptableObject, int x, int y)
    {
        BuildingScriptableObject = buildingScriptableObject;
        EntityType = EntityType.Building;
        X = x;
        Y = y;
    }
}
