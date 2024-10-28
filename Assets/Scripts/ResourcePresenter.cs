using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourcePresenter
{
    [SerializeField] Resource resource;
    [SerializeField] TileBase tileBase;

    public void Mine(out Resource minedResource) {
        minedResource = resource.Mine();

        if (resource.GetAmount() == 0)
        {
            
        }
    }
}