using System.Collections.Generic;

public class Mine : Building {
    public List<Point> Points {
        get;
        private set;
    } = new List<Point>();
    private void Awake() {
        Points = new List<Point>(GetComponentsInChildren<Point>());
    }
    private void Start() {
        OnDamageTaken += Mine_OnDamageTaken;
    }

    private void Mine_OnDamageTaken(object sender, System.EventArgs e) {
        GameEconomics.Instance.AddMoney(10);
    }
}
