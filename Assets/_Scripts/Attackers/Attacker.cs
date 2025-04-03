using UnityEngine;

public abstract class Attacker : MonoBehaviour, IAgent, IAttackable {
    public Vector2 TargetPostition {
        get;
        set;
    }

    public void Attack(IAttackable attackable, int damage) {
        throw new System.NotImplementedException();
    }

    public bool IsStopped() {
        throw new System.NotImplementedException();
    }

    public void MoveTo(Vector2 position) {
        
    }

    public void RotateTo(Vector2 position) {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage) {
        
    }
}