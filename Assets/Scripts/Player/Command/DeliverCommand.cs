using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeliverCommand : Command
{
    private DeliveryZone deliveryZone;
    private GameObject objToDeliver;

    public DeliverCommand(NavMeshAgent _agent, DeliveryZone dZone, GameObject objToDeliver) : base(_agent)
    {
        this.deliveryZone = dZone;
        this.agent = _agent;
        this.objToDeliver = objToDeliver;
    }

    public override bool isComplete => DeliveryComplete();

    public override void Execute()
    {
        agent.SetDestination(deliveryZone.transform.position);
    }

    public bool DeliveryComplete()
    {
        if (agent.remainingDistance > 1f)
        {
            return false;
        }

        if(deliveryZone != null && objToDeliver != null)
        {
            deliveryZone.Deliver(objToDeliver);
        }
        return true;
    }
}
  
