using TMPro;
using UnityEngine;

public class MoneyTextUI : MonoBehaviour {
    private TextMeshProUGUI textMesh;
    private void Awake() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        textMesh.text = GameEconomicsManager.Instance.Money.ToString();
        GameEconomicsManager.Instance.OnMoneyChanged += GameEconomics_OnMoneyChanged;
    }

    private void GameEconomics_OnMoneyChanged(object sender, GameEconomicsManager.OnMoneyChangedEventArgs e) {
        textMesh.text = e.money.ToString();
    }
}