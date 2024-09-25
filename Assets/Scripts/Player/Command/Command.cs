
using UnityEngine.AI;

public abstract class Command
{
    protected NavMeshAgent agent;

    public Command(NavMeshAgent _agent)
    {
        this.agent = _agent;
    }

    public abstract void Execute();

    public abstract bool isComplete { get; }
}
