using UnityEngine;

public class SwordWarrior : Defender {
    private Point _targetPoint;
    private void Start() {
        // Set the stats of the defender
        SetStats();
        foreach (Point point in ArmyUnit.Instance.Points) {
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
        //MoveTo(TargetPostition);
        if (IsStopped()) {
            // Wait or attack
        }
        else {
            MoveTo(TargetPostition);
        }
    }
    public override void Attack(IAttackable attackable, int damage) {
        attackable.TakeDamage(damage);
    }
}
