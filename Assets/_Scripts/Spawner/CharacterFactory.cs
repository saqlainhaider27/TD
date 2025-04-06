using UnityEngine;

public abstract class CharacterFactory : MonoBehaviour {
    [SerializeField] protected Transform _spawnLocation;

    public IAgent SpawnAt(GameObject spawnPrefab, Transform position) {
        return SpawnAt(spawnPrefab, position.position);
    }
    public IAgent SpawnAt(GameObject spawnPrefab, Vector3 position) {
        IAgent spawnedAgent  = null;
        if (spawnPrefab == null) {
            Debug.LogError("SpawnPrefab is null");
            return spawnedAgent;
        }
        GameObject spawnedObject = Instantiate(spawnPrefab, position, Quaternion.identity);
        if (spawnedObject.TryGetComponent<IAgent>(out IAgent agent)) {
            spawnedAgent = agent;
            AgentManager.Instance.AddTarget(agent);
        }
        else {
            Destroy(spawnedObject);
            Debug.LogError("Spawned object does not have IAgent component");
            return spawnedAgent;
        }
        return spawnedAgent;

    }
    public abstract IAgent Spawn();
}