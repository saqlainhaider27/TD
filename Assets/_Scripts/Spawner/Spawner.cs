using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private Transform spawnPrefab;
    [SerializeField] private Transform spawnPosition;
    public void SpawnAt(Transform spawnPrefab, Transform position) {
        SpawnAt(spawnPrefab, position.position);
    }
    public void SpawnAt(Transform spawnPrefab, Vector3 position) {
        if (spawnPrefab == null) {
            Debug.LogError("SpawnPrefab is null");
            return;
        }
        Transform spawn = Instantiate(spawnPrefab, position, Quaternion.identity);
        spawn.gameObject.SetActive(true);
    }
}