using UnityEngine;

public class Point : MonoBehaviour {
    public bool Occupied {
        get; set;
    }
    public Building Building {
        get; private set;
    }
    private void Awake() {
        Building = GetComponentInParent<Building>();
    }
}
