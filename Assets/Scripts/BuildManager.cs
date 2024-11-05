using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GridManager GridManager;
    private BuildSystem BuildSystem;
    private GameObject BuildPreview;
    public BuildingPrefab minePrefab;
    public BuildingPrefab beltPrefab;
    public BuildingPrefab smelterPrefab;

    public BuildingPrefab selectedBuildingPrefab;

    void Start()
    {
        GridManager = GameObject.FindObjectOfType<GridManager>();

        BuildSystem = new BuildSystem(
            1f,
            new Vector3(0, 0),
            new Dictionary<BuildingType, GameObject>
            {
                { minePrefab.BuildingType, minePrefab.Prefab },
                { beltPrefab.BuildingType, beltPrefab.Prefab },
                { smelterPrefab.BuildingType, smelterPrefab.Prefab },
            },
            GridManager.GetGridSystem()
        );
    }

    void Update()
    {
        if (selectedBuildingPrefab == null)
        {
            return;
        }
        
        BuildSystem.GetGridSnappedMousePosition(out Vector3 outPosition);
        BuildPreview.transform.position = outPosition;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClearBuildPreview();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!Utils.IsMouseOverUI())
            {
                BuildSystem.PlaceBuilding(outPosition, selectedBuildingPrefab);
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    ClearBuildPreview();
                }
            }
        }
    }

    public void SetSelectedBuilding(BuildingPrefab buildingPrefab)
    {
        selectedBuildingPrefab = buildingPrefab;

        CreateBuildPreview();
    }

    public void CreateBuildPreview()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        BuildSystem.CreateBuildPreview(
            mousePosition.x,
            mousePosition.y,
            new BuildingEntity(
                selectedBuildingPrefab.BuildingType,
                selectedBuildingPrefab.CraftingSpeed
            ),
            out BuildPreview
        );
    }

    public void ClearBuildPreview()
    {
        GameObject.Destroy(BuildPreview);
        selectedBuildingPrefab = null;
    }
}
