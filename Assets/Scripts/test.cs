using UnityEngine;

public class test : MonoBehaviour
{
    public void Start()
    {
        GridSystem<GridObject> grid = new(100, 100, 1, new Vector3(0, 0, 0));
    }
}