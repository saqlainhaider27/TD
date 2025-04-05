using UnityEngine;

public class AttackerFactory : CharacterFactory {
    [SerializeField] protected AttackerSO _attackerSO;
    public override IAgent Spawn() {
        return SpawnAt(_spawnPrefab, _spawnLocation.position);
    }
}
