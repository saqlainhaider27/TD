using UnityEngine;

public abstract class Attacker : GameCharacterBase{
    protected IAttackable _target;

    [field: SerializeField]
    public AttackerSO AttackerSO {
        get; private set;
    }
    public void FollowAttackTarget() {
        MoveTo(_target.Position);
    }
    public void SetStats() {
        Health = AttackerSO.Health;
        MoveSpeed = AttackerSO.Speed;
        StopThreshold = AttackerSO.StoppingDistance;
    }
}