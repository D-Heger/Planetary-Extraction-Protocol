using System.Collections.Generic;
using UnityEngine;

public class BuildingEntity : GridEntity
{
    public List<ResourceEntity> InputStorage;
    public List<ResourceEntity> OutputStorage;
    public BuildingScriptableObject BuildingScriptableObject;
    public int X;
    public int Y;

    public BuildingEntity(BuildingScriptableObject buildingScriptableObject, int x, int y)
    {
        BuildingScriptableObject = buildingScriptableObject;
        X = x;
        Y = y;
    }
}
