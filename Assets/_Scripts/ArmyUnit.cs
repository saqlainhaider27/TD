using System.Collections.Generic;
using UnityEngine;

public class ArmyUnit : Singleton<ArmyUnit> {
    public List<Point> Points {
        get;
        private set;
    } = new List<Point>();
    private void Awake() {
        Points = new List<Point>(GetComponentsInChildren<Point>());
    }
}
