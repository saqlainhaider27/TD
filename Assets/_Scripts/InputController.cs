using System;
using UnityEngine;

public class InputController : Singleton<InputController> {
    private InputSystem_Actions _inputActions;
    public event EventHandler OnClick;
    private void Awake() {
        _inputActions = new InputSystem_Actions();
    }
    private void Start() {
        _inputActions.Player.Attack.performed += Attack_performed;
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnClick?.Invoke(this, EventArgs.Empty);
    }

    private void OnEnable() {
        _inputActions.Enable();
    }
    private void OnDisable() {
        _inputActions.Disable();
    }
}