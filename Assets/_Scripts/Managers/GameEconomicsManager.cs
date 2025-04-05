using System;
using UnityEngine;

public class GameEconomicsManager : Singleton<GameEconomicsManager> {
    public event EventHandler<OnMoneyChangedEventArgs> OnMoneyChanged;
    public class OnMoneyChangedEventArgs : EventArgs {
        public int money;
    }
    private int _money = 150;
    public int Money {
        get => _money;
        private set {
            if (value < 0) {
                Debug.LogError("Money cannot be negative");
                return;
            }
            _money = value;
            OnMoneyChanged?.Invoke(this, new OnMoneyChangedEventArgs {
                money = _money
            });
        }
    }
    public void AddMoney(int amount) {
        if (amount < 0) {
            Debug.LogError("Cannot pass negative money");
            return;
        }
        Money += amount;
    }
    public void RemoveMoney(int amount) {
        if (amount < 0) {
            Debug.LogError("Cannot pass negative money");
            return;
        }
        Money -= amount;
    }
}