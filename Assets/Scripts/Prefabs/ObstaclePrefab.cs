using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclePrefab", menuName = "Grid/ObstaclePrefab")]
public class ObstaclePrefab : ScriptableObject
{
    public ObstacleType ObstacleType;
    public GameObject Prefab;
}