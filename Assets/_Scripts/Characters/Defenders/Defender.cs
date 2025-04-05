using UnityEngine;

public abstract class Defender : GameCharacterBase {

    [field: SerializeField]
    public DefenderSO DefenderSO { get; private set; }
    public void SetStats() {
        Health = DefenderSO.Health;
        MoveSpeed = DefenderSO.Speed;
        StopThreshold = DefenderSO.StoppingDistance;
    }
}
