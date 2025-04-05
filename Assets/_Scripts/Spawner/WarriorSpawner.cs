using System;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawner : DefenderFactory {
    [SerializeField] private ArmyUnit _armyUnit;
    private List<Point> _points = new List<Point>();
    private int _totalOccupied;

    private void Awake() {
        _armyUnit = ArmyUnit.Instance;
    }
    private void Start() {
        foreach (Point point in _armyUnit.Points) {
            _points.Add(point);
        }
        UIManager.Instance.OnSwordWarriorButtonPressed += UIManager_OnWarriorButtonPressed;
    }
    private void UIManager_OnWarriorButtonPressed() {
        Spawn();
    }
    public override IAgent Spawn() {
        if (_points.Count == 0) {
            Debug.LogError("No elements in list");
            return null;
        }
        if (_totalOccupied >= _points.Count) {
            return null;
        }
        _totalOccupied++;
        return base.Spawn();
    }
}
