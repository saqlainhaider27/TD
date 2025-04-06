using System.Collections.Generic;
using UnityEngine;

public class AttackerFactory : CharacterFactory {    
    [System.Serializable]
    public class SpawnableAttacker {
        public AttackerSO _attackerSO;
        [Range(0,100)]
        public float _spawnRate; // This will be a percentage value
    }
    [SerializeField] private List<SpawnableAttacker> _spawnableAttackers = new List<SpawnableAttacker>();

    private void Update() {
        
    }


    public override IAgent Spawn() {
        return SpawnAt(_spawnableAttackers[0]._attackerSO.SpawnPrefab, _spawnLocation.position);
    }
}
