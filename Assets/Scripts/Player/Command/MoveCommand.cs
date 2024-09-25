using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent agent;
    private Vector3 destination;

    public MoveCommand(NavMeshAgent _agent, Vector3 _destination) : base(_agent)
    {
        this.agent = _agent;
        this.destination = _destination;
    }

    public override bool isComplete => ReachedDestination();

    public override void Execute()
    {
        agent.SetDestination(destination);
    }

    bool ReachedDestination()
    {
        if(agent.remainingDistance >= 0.05f)
        {
            return false;
        }
        else if (agent.velocity.magnitude <= 0.2f)
        {
            return true;
        }
        else
        {
            return true;
        }
    }
}
