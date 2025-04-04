using UnityEngine;

public abstract class AgentSpawner : MonoBehaviour {
    [SerializeField] protected GameObject _spawnPrefab;
    [SerializeField] protected Transform _spawnLocation;
    [SerializeField] protected DefenderSO _defenderSO;
    public abstract void Spawn();
    public void SpawnAt(GameObject spawnPrefab, Transform position) {
        SpawnAt(spawnPrefab, position.position);
    }
    public void SpawnAt(GameObject spawnPrefab, Vector3 position) {
        if (spawnPrefab == null) {
            Debug.LogError("SpawnPrefab is null");
            return ;
        }
        GameObject spawnedObject = Instantiate(spawnPrefab, position, Quaternion.identity);
        if (spawnedObject.TryGetComponent<IAttackable>(out IAttackable attackable)) {
            TargetManager.Instance.AddTarget(attackable);
        }
    }
    public bool HasEnoughMoney() {
        return GameEconomics.Instance.Money >= _defenderSO.Cost;
    }
    public void DecrementCost() {
        GameEconomics.Instance.RemoveMoney(_defenderSO.Cost);
    }
}
