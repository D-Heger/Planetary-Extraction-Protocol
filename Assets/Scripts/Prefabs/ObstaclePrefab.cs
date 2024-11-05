using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclePrefab", menuName = "Prefabs/ObstaclePrefab")]
public class ObstaclePrefab : ScriptableObject
{
    public ObstacleType ObstacleType;
    public GameObject Prefab;
}