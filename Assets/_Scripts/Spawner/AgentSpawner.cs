using UnityEngine;

public abstract class AgentSpawner : MonoBehaviour {
    [SerializeField] protected GameObject _spawnPrefab;
    [SerializeField] protected Transform _spawnLocation;
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
    }
}
