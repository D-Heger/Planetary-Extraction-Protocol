using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclePrefab", menuName = "Prefabs/ObstaclePrefab")]
public class ObstacleScriptableObject : ScriptableObject
{
    public ObstacleType ObstacleType;
    public GameObject Prefab;
}