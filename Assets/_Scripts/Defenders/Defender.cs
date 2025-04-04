using UnityEngine;

public abstract class Defender : GameCharacterBase {

    [field: SerializeField]
    public DefenderSO DefenderSO { get; private set; }
}
