using System;
using UnityEngine;

public abstract class Building : MonoBehaviour, IAttackable {
    public event EventHandler OnDamageTaken;
    public int Health {
        get; set;
    } = 100;
    public Vector2 Position {
        get;
        set;
    }
    public bool IsDead {
        get;
        set;
    }

    private void Start() {
        Position = transform.position;
    }
    public void TakeDamage(int damage) {
        if (Health <= 0) {
            Die();
            return;
        }
        if ((Health - damage) <= 0) {
            Die();
            return;
        }
        Health -= damage;
        OnDamageTaken?.Invoke(this, EventArgs.Empty);
    }

    private void Die() {
        Health = 0;
        Destroy(gameObject);
    }
}
