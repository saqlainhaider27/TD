using UnityEngine;

public abstract class Defender : MonoBehaviour, IAgent, IAttackable {
    [field: SerializeField]
    public int Health { get; private set; } = 100;
    [field: SerializeField]
    public float Speed { get; set; } = 1f;
    [field: SerializeField]
    public int cost {
        get;
        private set;
    } = 150;

    public Vector2 TargetPostition {
        get;
        set;
    }

    private float _stopThreshold = 0.1f;
    private float _currentVelocity;

    public void MoveTo(Vector2 position) {
        TargetPostition = position;
        if (IsStopped()) {
            return;
        }
        Vector2 direction = (TargetPostition - (Vector2)transform.position).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
        //RotateTo(position);
        // If the target position is in front of the defender rotate 0 degrees in z if behind rotate 180 degrees in z
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
        if (Vector2.Distance(transform.position, TargetPostition) <= _stopThreshold) {
            return true;
        }
        return false;
    }
    public abstract void TakeDamage(int damage);
    public abstract void Attack(IAttackable attackable, int damage);
}
