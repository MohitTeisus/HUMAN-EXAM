using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotState : BaseState
{
    protected FriendlyRobot robot;

    public RobotState(FriendlyRobot robot)
    {
        this.robot = robot;
    }

    public abstract void OnCollisionEnter(Collider other);
}
