using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStrategy : IEquipStrategy
{
    EquipInteractor interactor;
    RobotCommand robotCommand;

    public CommandStrategy(EquipInteractor interactor, RobotCommand rCommand)
    {
        this.interactor = interactor;
        this.robotCommand = rCommand;
        interactor.commandWand.SetActive(true);
    }

    public void UseEquipment()
    {
        //Plays audio
        Observer.playSound("Command");
        //Plays animation
        Observer.onShoot();

        robotCommand.Command(interactor.commandPool);
    }
}
