using UnityEngine;

public class SwordWarrior : Defender {
    private Vector2 location = new Vector2(10, 10);
    private void Update() {
        MoveTo(location);
        if (IsStopped()) {
            location = Vector2.zero;
            MoveTo(location);
        }
    }
    public override void Attack(IAttackable attackable, int damage) {
        attackable.TakeDamage(damage);
    }

    public override void TakeDamage(int damage) {

    }


}
