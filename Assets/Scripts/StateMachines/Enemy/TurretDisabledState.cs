using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDisabledState : TurretState
{
    public TurretDisabledState(Turret _turret) : base(_turret)
    {

    }

    public override void OnStateEnter()
    {
        turret.turretAudio.Play();
        turret.lineRenderer.enabled = false;
    }

    public override void OnStateExit()
    {
        turret.lineRenderer.enabled = true;
    }

    public override void OnStateUpdate()
    {

    }
}
