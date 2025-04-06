using UnityEngine;

public abstract class DefenderFactory : CharacterFactory {
    [SerializeField] protected DefenderSO _defenderSO;
    public override IAgent Spawn() {
        DecrementCost();
        return SpawnAt(_defenderSO.SpawnPrefab, _spawnLocation.position);
    }
    public bool HasEnoughMoney() {
        return GameEconomicsManager.Instance.Money >= _defenderSO.Cost;
    }
    public void DecrementCost() {
        GameEconomicsManager.Instance.RemoveMoney(_defenderSO.Cost);
    }
}
