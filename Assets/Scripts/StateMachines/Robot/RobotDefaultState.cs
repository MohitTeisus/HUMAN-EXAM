using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDefaultState : RobotState
{
    public RobotDefaultState(FriendlyRobot robot) : base(robot)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Entered Robot Default state");
    }

    public override void OnStateExit()
    {
        Debug.Log("Exited Robot Default state");    
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RobotPickable"))
        {
            robot.ChangeState(new RobotItemPickedState(robot));

            //Attach object to the Robot
            other.transform.position = robot.attachPoint.position;
            other.transform.parent = robot.attachPoint;
            robot.attachedObject = other.gameObject;
        }
    }
}
