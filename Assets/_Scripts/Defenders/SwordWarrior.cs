using UnityEngine;

public class SwordWarrior : Defender {

    private void Start() {
        InputController.Instance.OnClick += InputController_OnClick;
    }
    private void InputController_OnClick(object sender, System.EventArgs e) {
        // Get the mouse position in 2D space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Move the defender to the mouse position
        TargetPostition = mousePosition;
    }
    private void Update() {
        MoveTo(TargetPostition);
    }
    public override void Attack(IAttackable attackable, int damage) {
        attackable.TakeDamage(damage);
    }
    public override void TakeDamage(int damage) {

    }
}
