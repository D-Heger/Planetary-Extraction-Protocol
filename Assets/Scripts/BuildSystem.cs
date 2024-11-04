using System.Collections.Generic;
using System;
using UnityEngine;

public class BuildSystem
{
    private float CellSize;
    private Vector3 OriginPosition;
    private Dictionary<BuildingType, GameObject> BuildingPrefabs;

    public BuildSystem(
        float cellSize,
        Vector3 originPosition,
        Dictionary<BuildingType, GameObject> buildingPrefabs
    )
    {
        CellSize = cellSize;
        OriginPosition = originPosition;
        BuildingPrefabs = buildingPrefabs;
    }

    public void CreateBuildPreview(float x, float y, BuildingEntity buildingEntity, out GameObject buildingPreview) {

        BuildingPrefabs.TryGetValue(buildingEntity.BuildingType, out var buildingPrefab);
        Vector3 position = new Vector3(x, y) * CellSize + OriginPosition + new Vector3(CellSize, CellSize) * 0.5f;

        buildingPreview = GameObject.Instantiate(buildingPrefab, position, Quaternion.identity);

        buildingPreview.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    public void GetGridSnappedMousePosition(out Vector3 outPosition)
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        mousePosition.x = Mathf.Floor(mousePosition.x);
        mousePosition.y = Mathf.Floor(mousePosition.y);

        outPosition = mousePosition * CellSize + OriginPosition + new Vector3(CellSize, CellSize) * 0.5f;
        outPosition.z = -1; //TODO rework dirty fix
    }
}