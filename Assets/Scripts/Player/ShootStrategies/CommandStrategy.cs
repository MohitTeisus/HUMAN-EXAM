using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStrategy : IShootStrategy
{
    EquipInteractor interactor;
    RobotCommand robotCommand;

    public CommandStrategy(EquipInteractor interactor, RobotCommand rCommand)
    {
        this.interactor = interactor;
        interactor.commandWand.SetActive(true);
    }

    public void Shoot()
    {
        robotCommand.Command();
    }
}
