using UnityEngine;

public interface IAgent {
    public Vector2 TargetPostition {
        get;
        set;
    }
    void MoveTo(Vector2 position);
    void RotateTo(Vector2 position);
    void Attack(IAttackable attackable, int damage);
    bool IsStopped();
}
