using UnityEngine;

public interface IAttackable {
    public Vector2 Position {
        get; 
        set; 
    }
    void TakeDamage(int damage);
}
