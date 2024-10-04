using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    private PlayerHealth playerHealth;
    [SerializeField]

    public TurretAttackState(Turret _turret) : base(_turret)
    {
        playerHealth = turret.player.GetComponent<PlayerHealth>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Turret starting attack");
    }

    public override void OnStateExit()
    {
        Debug.Log("Turret lost player, returning to idle");
    }

    public override void OnStateUpdate()
    {
        if (Physics.SphereCast(turret.turretGun.position, turret.checkRadius, turret.transform.forward, out RaycastHit hit, turret.playerCheckDistance) && hit.transform.CompareTag("Player"))
        {
            Attack();
            turret.DrawLaser(hit.point);
        }
        else
        {
            turret.ChangeTurretState(new TurretIdleState(turret));
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.DeductHealth(turret.damagePerSecond * Time.deltaTime);
        }
    }

}
