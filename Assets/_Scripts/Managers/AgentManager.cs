using System.Collections.Generic;

public class AgentManager : Singleton<AgentManager> {
    public List<IAgent> agents = new List<IAgent>();
    public void AddTarget(IAgent agent) {
        agents.Add(agent);
    }
    public void RemoveTarget(IAgent agent) {
        agents.Remove(agent);
    }
}
