using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    [SerializeField] private Button _minerButton;
    public event Action OnMinerButtonPressed;
    private void Start() {
        _minerButton.onClick.AddListener(OnMinerButtonClicked);
    }
    private void OnMinerButtonClicked() {
        OnMinerButtonPressed?.Invoke();
    }
}
