using System.Collections;
using UnityEngine;

public class MiningProcess : MonoBehaviour {
    
    [SerializeField] private float _speed;
    private ObjectStorage _objectStorage;
    private BuildingEntity _buildingEntity;
    private ResourceEntity _resourceEntity;

    private void Mine()
    {
        _resourceEntity.Amount--;
        _buildingEntity.OutputStorage.Add(_resourceEntity);
    }

    private void Awake()
    {
        _objectStorage = GetComponent<ObjectStorage>();
        _buildingEntity = _objectStorage.GetObject<BuildingEntity>();
        _resourceEntity = (ResourceEntity)GridManager.Instance.GetGridSystem().GetCell(_buildingEntity.X, _buildingEntity.Y).GetEnvEntity();
    }

    private void Start()
    {
        StartCoroutine(Process(_speed));
    }

    private IEnumerator Process(float seconds)
    {
        Mine();
        yield return new WaitForSeconds(seconds);
    }
}