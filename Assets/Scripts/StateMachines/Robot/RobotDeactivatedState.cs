using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDeactivatedState : RobotState
{
    public RobotDeactivatedState(FriendlyRobot robot) : base(robot)
    {

    }

    public override void OnCollisionEnter(Collider other)
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("Robot finished all tasks, Deactivating");
        robot.agent.destination = robot.completionPoint.position;
    }

    public override void OnStateExit()
    {
        Debug.Log("Robot reactivating");
        robot.SetActivity(true);
    }

    public override void OnStateUpdate()
    {
        
    }
}
