using UnityEngine;

public class Miner : Defender {
    [SerializeField] private float mineCooldown = 2.0f;
    private float lastMineTime;
    private Point _targetPoint;

    private void Start() {
        SetStats();
        // Miner is spawned
        // Check which mine is not occupied
        foreach (Point point in MinerSpawner.Instance.MinePointList) {
            if (point.Occupied == false) {
                // Set the spawn location
                // Move the miner to the Mine
                _targetPoint = point;
                TargetPostition = _targetPoint.transform.position;
                point.Occupied = true;
                break;
            }
        }
    }

    private void Update() {
        Position = transform.position;
        if (IsStopped()) {
            // Start Mining
            Mine();
        }
        else {
            // Move to the target point
            MoveTo(TargetPostition);
        }
    }

    private void Mine() {
        if (Time.time >= lastMineTime + mineCooldown) {
            lastMineTime = Time.time;
            Attack(_targetPoint.Building, DefenderSO.Damage);
        }
    }

    public override void Attack(IAttackable attackable, int damage) {
        attackable.TakeDamage(damage);
    }
}
