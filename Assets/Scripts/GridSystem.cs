using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GridSystem<GridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private GridObject[,] worldGrid;
    private GridObject[,] structureGrid;
    private TextMeshPro[,] debugTextArray;

    public GridSystem(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        worldGrid = new GridObject[width, height];
        structureGrid = new GridObject[width, height];
        debugTextArray = new TextMeshPro[width, height];

        for (int x = 0; x < worldGrid.GetLength(0); x++)
        {
            for (int y = 0; y < worldGrid.GetLength(1); y++)
            {
                // debugTextArray[x, y] = Utils.CreateWorldText(worldGrid[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 10);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetObject(int x, int y, GridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            worldGrid[x, y] = value;
            debugTextArray[x, y].text = worldGrid[x, y].ToString();
        }
    }

    public void SetObject(Vector3 worldPosition, GridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetObject(x, y, value);
    }

    public GridObject GetObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return worldGrid[x, y];
        }
        else
        {
            Debug.LogWarning("Grid: " + x + ", " + y + " is out of bounds.");

            return default;
        }
    }

    public GridObject GetObjectWithWorldPosition(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);

        return GetObject(x, y);
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetOriginPosition()
    {
        return originPosition;
    }
}
