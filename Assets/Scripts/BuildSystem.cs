using UnityEngine;

public class BuildSystem
{
    private float CellSize;
    private Vector3 OriginPosition;
    private GridSystem GridSystem;

    public BuildSystem(
        float cellSize,
        Vector3 originPosition,
        GridSystem gridSystem
    )
    {
        CellSize = cellSize;
        OriginPosition = originPosition;
        GridSystem = gridSystem;
    }

    public void CreateBuildPreview(float x, float y, BuildingScriptableObject buildingScriptableObject, out GameObject buildingPreview)
    {
        Vector3 position = new Vector3(x, y) * CellSize + OriginPosition + new Vector3(CellSize, CellSize) * 0.5f;

        SpriteRenderer spriteRenderer = buildingScriptableObject.Prefab.GetComponent<SpriteRenderer>();

        buildingPreview = GameObject.Instantiate(CreatePreviewGameObject(spriteRenderer), position, Quaternion.identity);


        buildingPreview.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    private GameObject CreatePreviewGameObject(SpriteRenderer spriteRenderer) {
        GameObject newGameObject = new("SpriteObject");

        SpriteRenderer newSpriteRenderer = newGameObject.AddComponent<SpriteRenderer>();
        newSpriteRenderer.sprite = spriteRenderer.sprite;

        return newGameObject;
    }

    public void GetGridSnappedMousePosition(out Vector3 outPosition)
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        mousePosition.x = Mathf.Floor(mousePosition.x);
        mousePosition.y = Mathf.Floor(mousePosition.y);

        outPosition = mousePosition * CellSize + OriginPosition + new Vector3(CellSize, CellSize) * 0.5f;
        outPosition.z = -1; //TODO rework dirty fix
    }

    public void PlaceBuilding(Vector3 position, BuildingScriptableObject buildingScriptableObject)
    {
        GridSystem.PlaceBuilding(buildingScriptableObject, (int)position.x, (int)position.y);
    }
}
