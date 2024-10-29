using UnityEngine;

public class GridCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public GridEntity Entity { get; set; }
    public GameObject VisualRepresentation { get; set; }

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
        Entity = null;
    }

    public bool IsOccupied => Entity != null && !Entity.CanOccupy();

    public void SetEntity(GridEntity entity)
    {
        Entity = entity;
    }

    public void RemoveEntity()
    {
        Entity = null;
    }
}
