using System;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public List<GridEntity> Entities { get; private set; }
    public GameObject VisualRepresentation { get; set; }

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
        Entities = new List<GridEntity>();
    }

    public bool IsOccupied => Entities.Exists(entity => entity.CanOccupy());

    public GridEntity GetTopEntity() {
        if (Entities.Count == 0) return null;

        Entities.Sort((a, b) => a.EntityType.CompareTo(b.EntityType));
        return Entities[0];
     }

    public void AddEntity(GridEntity entity)
    {
        Entities.Add(entity);
    }

    public void RemoveEntity(GridEntity entity)
    {
        Entities.Remove(entity);
    }

    public void ClearEntities()
    {
        Entities.Clear();
    }
}
