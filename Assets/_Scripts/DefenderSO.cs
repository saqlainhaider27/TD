using UnityEngine;

[CreateAssetMenu(fileName = "DefenderSO", menuName = "Scriptable Objects/DefenderSO")]
public class DefenderSO : ScriptableObject {
    [field: SerializeField]
    public float Health { get; private set; } = 100;
    [field: SerializeField]
    public float Speed { get; set; } = 1f;
    [field: SerializeField]
    public int Cost {
        get;
        private set;
    } = 150;
    [field: SerializeField]
    public int Damage {
        get;
        private set;
    } = 0;
    [field: SerializeField]
    public float StoppingDistance {
        get;
        private set;
    } = 1f;
}
