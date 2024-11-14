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
        Debug.Log("Amount: " + _resourceEntity.Amount);
        Debug.Log("Storage: " + _buildingEntity.OutputStorage.Count);
    }

    private void Awake()
    {
        _objectStorage = GetComponent<ObjectStorage>();
    }

    public void Start() 
    {
        _buildingEntity = _objectStorage.GetObject<BuildingEntity>();
        _resourceEntity = GridManager.Instance.GetGridSystem().GetCell(_buildingEntity.X, _buildingEntity.Y).GetResourceEntity();
        StartCoroutine(Process(_speed));
    }

    private IEnumerator Process(float seconds)
    {
        //TODO remove resource entity from grid cell when amount is 0
        while (_resourceEntity.Amount > 0)
        {
            Mine();
            yield return new WaitForSeconds(seconds);
        }
    }
}