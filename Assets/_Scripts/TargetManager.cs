using System.Collections.Generic;

public class TargetManager : Singleton<TargetManager> {
    public List<IAttackable> attackables = new List<IAttackable>();
    private void Start() {
        AddTarget(Castle.Instance);
    }
    public void AddTarget(IAttackable attackable) {
        attackables.Add(attackable);
    }
    public void RemoveTarget(IAttackable attackable) {
        attackables.Remove(attackable);
    }
}
