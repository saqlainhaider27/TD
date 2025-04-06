using System.Collections.Generic;
using UnityEngine;

public class MinerSpawner : DefenderFactory {
    public List<Point> MinePointList {
        get;
        private set;
    } = new List<Point>();

    [field: SerializeField]
    public List<Mine> Mines {
        get;
        private set;
    } = new List<Mine>();

    private int _totalOccupied = 0;
    public static MinerSpawner Instance;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogError("More than one instance of MinerSpawner on scene");
        }
        else {
            Instance = this;
        }
    }

    private void Start() {
        foreach (Mine mine in Mines) {
            foreach (Point point in mine.Points) {
                MinePointList.Add(point);
            }
        }
        UIManager.Instance.OnMinerButtonPressed += UIManager_OnMinerButtonPressed;
    }

    private void UIManager_OnMinerButtonPressed() {
        Spawn();
    }

    public override IAgent Spawn() {
        if (!HasEnoughMoney()) {
            return null;
        }
        if (MinePointList.Count == 0) {
            Debug.LogError("No elements in list");
            return null;
        }
        if (_totalOccupied >= MinePointList.Count) {
            Debug.Log(_totalOccupied);
            return null;
        }
        _totalOccupied++;
        return base.Spawn();
    }
}
