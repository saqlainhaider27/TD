using System;
using System.Collections.Generic;
using UnityEngine;


public class AgentManager : Singleton<AgentManager> {
    public List<IAgent> Agents {
        get; private set;
    } = new List<IAgent>();
    public void AddTarget(IAgent agent) {
        Agents.Add(agent);
        Debug.Log(agent);
    }
    public void RemoveTarget(IAgent agent) {
        Agents.Remove(agent);
    }
}
