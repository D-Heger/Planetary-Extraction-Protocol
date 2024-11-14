using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GridManager GridManager;
    private BuildSystem BuildSystem;
    private GameObject BuildPreview;
    private BuildingScriptableObject selectedBuildingScriptableObject;
    public static BuildManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GridManager = GameObject.FindObjectOfType<GridManager>();

        BuildSystem = new BuildSystem(
            1f,
            new Vector3(0, 0),
            GridManager.GetGridSystem()
        );
    }

    void Update()
    {
        if (selectedBuildingScriptableObject == null)
        {
            return;
        }
        
        BuildSystem.GetGridSnappedMousePosition(out Vector3 outPosition);
        BuildPreview.transform.position = outPosition;

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            ClearBuildPreview();
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!Utils.IsMouseOverUI())
            {
                BuildSystem.PlaceBuilding(outPosition, selectedBuildingScriptableObject);
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    ClearBuildPreview();
                }
            }
        }
    }

    public void SetSelectedBuilding(BuildingScriptableObject buildingScriptableObject)
    {
        selectedBuildingScriptableObject = buildingScriptableObject;

        CreateBuildPreview();
    }

    public void CreateBuildPreview()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        BuildSystem.CreateBuildPreview(
            mousePosition.x,
            mousePosition.y,
            selectedBuildingScriptableObject,
            out BuildPreview
        );
    }

    public void ClearBuildPreview()
    {
        GameObject.Destroy(BuildPreview);
        selectedBuildingScriptableObject = null;
    }
}
