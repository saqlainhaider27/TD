using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

    [SerializeField] private Button _minerButton;
    [SerializeField] private Button _swordWarriorButton;

    public event Action OnMinerButtonPressed;
    public event Action OnSwordWarriorButtonPressed;

    private void Start() {
        _minerButton.onClick.AddListener(OnMinerButtonClicked);
        _swordWarriorButton.onClick.AddListener(OnSwordWarriorButtonClicked);
    }

    private void OnSwordWarriorButtonClicked() {
        OnSwordWarriorButtonPressed?.Invoke();
    }

    private void OnMinerButtonClicked() {
        OnMinerButtonPressed?.Invoke();
    }
}
