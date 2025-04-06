using UnityEngine;

public abstract class Attacker : GameCharacterBase{
    protected IAttackable _target;
    private float _nearestDistance;
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

        _nearestDistance = Vector2.Distance(transform.position, Castle.Instance.Position);
    }
    public IAttackable GetNearestTarget() {
        IAttackable target = Castle.Instance;
        foreach (IAttackable attackable in AgentManager.Instance.Agents) {
            if (attackable is Attacker) {
                continue;
            }
            float distanceToTarget = Vector2.Distance(Position, attackable.Position);
            if (distanceToTarget < _nearestDistance) {
                _nearestDistance = distanceToTarget;
                target = attackable;
            }
        }
        return target;
    }
}