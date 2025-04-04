using UnityEngine;

public class Castle : Building {
    public static Castle Instance;
    private void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogError("More than one castle on scene");
        }
        else {
            Instance = this;
        }
    }
}