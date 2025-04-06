using UnityEngine;

public class BruteAttacker : Attacker {

    
    private float _attackCooldown;
    private void Start() {
        SetStats();
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
    public override void Attack(IAttackable attackable, int damage) {
        if (attackable == null) {
            return;
        }
        attackable.TakeDamage(damage);
    }
}
