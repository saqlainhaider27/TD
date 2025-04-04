using UnityEngine;

public class BruteAttacker : Attacker {

    private float _nearestDistance;
    private void Start() {
        SetStats();
        _nearestDistance = Vector2.Distance(transform.position, Castle.Instance.Position);
    }
    private void Update() {
        // TODO: The attacker does not take reference to the next target when it kills the current target
        Position = transform.position;
        Debug.Log(_target);
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
        // TODO: Add and attack delay to the BruteAttacker
        attackable.TakeDamage(damage);
    }
}
