using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretState
{
    public TurretIdleState(Turret _turret) : base(_turret)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Turret Entering Idle");
        turret.DrawLaser(turret.turretGun.position + turret.turretGun.forward * turret.playerCheckDistance);
        //Line Renderer
    }

    public override void OnStateExit()
    {
        Debug.Log("Turret Detected Player");
    }

    public override void OnStateUpdate()
    {
        if (Physics.SphereCast(turret.turretGun.position, turret.checkRadius, turret.transform.forward, out RaycastHit hit, turret.playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                turret.player = hit.transform;
                turret.ChangeTurretState(new TurretAttackState(turret));
            }
            else
            {
                turret.DrawLaser(hit.point);
            }
        }
        else
        {
            turret.DrawLaser(turret.turretGun.position + turret.turretGun.forward * turret.playerCheckDistance);
        }
    }
}
