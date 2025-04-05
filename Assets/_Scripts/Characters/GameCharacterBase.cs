using System;
using UnityEngine;

public abstract class GameCharacterBase : MonoBehaviour, IAgent, IAttackable {
    public bool IsDead {
        get; set;
    } = false;
    public float Health {
        get; protected set;
    }
    public float MoveSpeed {
        get; protected set;
    }
    public Vector2 TargetPostition {
        get;
        set;
    }
    public float StopThreshold {
        get;
        protected set;
    }
    public Vector2 Position {
        get; set;
    }
    private float _currentVelocity;
    public void MoveTo(Vector2 position) {
        TargetPostition = position;
        if (IsStopped()) {
            return;
        }
        Vector2 direction = (TargetPostition - (Vector2)transform.position).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * MoveSpeed * Time.deltaTime;
        transform.position = newPosition;
        FlipTo(direction);
    }

    private void FlipTo(Vector2 direction) {
        if (Vector2.Dot(direction, Vector2.right) > 0) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }

    public void RotateTo(Vector2 position) {
        Vector2 direction = position - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, angle, ref _currentVelocity, smoothTime: 0.1f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, smoothAngle));
    }

    public bool IsStopped() {
        if (Vector2.Distance(transform.position, TargetPostition) <= StopThreshold) {
            return true;
        }
        return false;
    }
    public void TakeDamage(int damage) {
        if (IsDead) {
            return;
        }
        if (Health <= 0) {
            Die();
            return;
        }
        if ((Health - damage) <= 0) {
            Die();
            return;
        }
        Health -= damage;
    }

    private void Die() {
        Health = 0;
        IsDead = true;
        AgentManager.Instance.RemoveTarget(this);
        Destroy(gameObject);
    }
    public abstract void Attack(IAttackable attackable, int damage);
}

