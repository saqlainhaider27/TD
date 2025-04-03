using UnityEngine;

public interface IAgent {
    void MoveTo(Vector2 position);
    void RotateTo(Vector2 position);
    void Attack(IAttackable attackable, int damage);
    bool IsStopped();
}
