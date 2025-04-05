using UnityEngine;

public class BruteAttacker : Attacker {

    private float _nearestDistance;
    private void Start() {
        SetStats();
        _nearestDistance = Vector2.Distance(transform.position, Castle.Instance.Position);
        _attackCooldown = 0f;
    }

    private void Update() {
        Position = transform.position;
        _attackCooldown -= Time.deltaTime;
        if (IsStopped()) {
            if (_target != null) {
                if (_attackCooldown <= 0f) {
                    Attack(_target, AttackerSO.Damage);
                    _attackCooldown = AttackerSO.AttackSpeed;
                }
                if (_target.IsDead) {
                    _target = GetNearestTarget();
                }
            }
            else {
                _target = GetNearestTarget();
            }
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
        foreach (IAttackable attackable in AgentManager.Instance.agents) {
            float distanceToTarget = Vector2.Distance(Position, attackable.Position);
            if (distanceToTarget < _nearestDistance) {
                _nearestDistance = distanceToTarget;
                target = attackable;
            }
        }
        return target;
    }

    private float _attackCooldown;



    public override void Attack(IAttackable attackable, int damage) {
        if (attackable == null) {
            return;
        }
        attackable.TakeDamage(damage);
    }
}
