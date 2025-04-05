using UnityEngine;

public abstract class DefenderFactory : CharacterFactory {
    [SerializeField] protected DefenderSO _defenderSO;
    public override IAgent Spawn() {
        if (!HasEnoughMoney()) {
            return null;
        }
        DecrementCost();
        return SpawnAt(_spawnPrefab, _spawnLocation.position);
    }
    public bool HasEnoughMoney() {
        return GameEconomicsManager.Instance.Money >= _defenderSO.Cost;
    }
    public void DecrementCost() {
        GameEconomicsManager.Instance.RemoveMoney(_defenderSO.Cost);
    }
}
