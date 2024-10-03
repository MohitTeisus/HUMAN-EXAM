using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotItemPickedState : RobotState
{
    public RobotItemPickedState(FriendlyRobot robot) : base(robot)
    {

    }

    public override void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("RobotDelivery"))
        {
            Debug.Log($"Delivered {robot.attachedObject.name}");
            robot.ChangeState(new RobotDefaultState(robot));
        }

        if (other.gameObject.CompareTag("RobotPickable"))
        {
            Observer.tooltip("ROBOT CAN ONLY HOLD ONE ITEM AT A TIME");
        }
    }

    public override void OnStateEnter()
    {
        Debug.Log("Entered Robot Item Picked state");
    }

    public override void OnStateExit()
    {
        robot.attachedObject = null;
        Debug.Log("Exited Robot Item Picked state");
    }

    public override void OnStateUpdate()
    {
       
    }
}
