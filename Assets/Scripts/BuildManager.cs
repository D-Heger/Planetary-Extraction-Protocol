using System.Collections.Generic;
using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private BuildSystem BuildSystem;
    private GameObject BuildPreview;
    public BuildingPrefab minePrefab;

    void Start()
    {
        BuildSystem = new BuildSystem(
            1f,
            new Vector3(0, 0),
            new Dictionary<BuildingType, GameObject>
            {
                { minePrefab.BuildingType, minePrefab.Prefab },
            }
        );

        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        BuildSystem.CreateBuildPreview(mousePosition.x, mousePosition.y, new BuildingEntity(BuildingType.Mine, 1), out BuildPreview);
    }

    void Update()
    {
        BuildSystem.GetGridSnappedMousePosition(out Vector3 outPosition);
        BuildPreview.transform.position = outPosition;
    }
}