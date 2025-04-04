using UnityEngine;

public class BruteAttacker : Attacker {

    private float _nearestDistance;
    private void Start() {
        MoveSpeed = AttackerSO.Speed;
        _nearestDistance = Vector2.Distance(transform.position, Castle.Instance.Position);
    }
    private void Update() {
        Position = transform.position;
        
        if (IsStopped()) {
            Attack(_target, AttackerSO.Damage);
        }
        else {
            _target = GetNearestTarget();
        }
        if (_target != null) {
            FollowAttackTarget();
        }

    }

    private IAttackable GetNearestTarget() {
        IAttackable target = Castle.Instance;
        foreach (IAttackable attackable in TargetManager.Instance.attackables) {
            float distanceToTarget = Vector2.Distance(Position, attackable.Position);
            if (distanceToTarget < _nearestDistance) {
                _nearestDistance = distanceToTarget;
                target = attackable;
            }
        }
        return target;
    }

    public override void Attack(IAttackable attackable, int damage) {
        attackable.TakeDamage(damage);
    }
}
