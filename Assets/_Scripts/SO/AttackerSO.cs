using UnityEngine;

[CreateAssetMenu(fileName = "AttackerSO", menuName = "Scriptable Objects/AttackerSO")]
public class AttackerSO : ScriptableObject {
    [field: SerializeField]
    public float Health { get; private set; } = 100;
    [field: SerializeField]
    public float Speed { get; private set; } = 1f;
    [field: SerializeField]
    public float AttackSpeed { get; private set;} = 1f;
    [field: SerializeField]
    public int Damage {
        get;
        private set;
    } = 10;
    [field: SerializeField]
    public float StoppingDistance {
        get;
        private set;
    } = 1f;
}