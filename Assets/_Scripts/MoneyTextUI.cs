using TMPro;
using UnityEngine;

public class MoneyTextUI : MonoBehaviour {
    private TextMeshProUGUI textMesh;
    private void Awake() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        textMesh.text = GameEconomics.Instance.Money.ToString();
        GameEconomics.Instance.OnMoneyChanged += GameEconomics_OnMoneyChanged;
    }

    private void GameEconomics_OnMoneyChanged(object sender, GameEconomics.OnMoneyChangedEventArgs e) {
        textMesh.text = e.money.ToString();
    }
}