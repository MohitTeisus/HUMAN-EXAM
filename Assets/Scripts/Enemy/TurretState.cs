using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretState : BaseState
{
    protected Turret turret;

    public TurretState (Turret _turret)
    {
        this.turret = _turret;
    }
}
