using UnityEngine;

public interface IAttackable {
    public Vector2 Position {
        get; 
        set; 
    }
    public bool IsDead {
        get;
        set;
    }
    void TakeDamage(int damage);

}
