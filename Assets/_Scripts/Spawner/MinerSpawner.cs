using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerSpawner : AgentSpawner {

    [SerializeField] private Button _minerButton;
    public List<Point> MinePointList {
        get;
        private set;
    } = new List<Point>();

    [field: SerializeField]
    public List<Mine> Mines {
        get;
        private set;
    } = new List<Mine>();

    private static int _totalOccupied = 0;
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
        _minerButton.onClick.AddListener(Spawn);
    }
    public override void Spawn() {
        if (MinePointList.Count == 0) {
            Debug.LogError("No elements in list");
            return;
        }
        if (_totalOccupied >= MinePointList.Count) {
            // Can't spawn so return
            return;
        }
        // TODO:
        // Check the current cost of the miner with the money player has
        // Spawn only if player has more money or equal money to the cost
        // Spawns the prefab
        SpawnAt(_spawnPrefab, _spawnLocation);
        _totalOccupied++;
    }
}
