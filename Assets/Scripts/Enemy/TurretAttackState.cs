using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    private Health playerHealth;
    [SerializeField]

    public TurretAttackState(Turret _turret) : base(_turret)
    {
        playerHealth = turret.player.GetComponent<Health>();
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
        if (Physics.Raycast(turret.turretGun.position, turret.transform.forward, out RaycastHit hit, turret.playerCheckDistance) && hit.transform.CompareTag("Player"))
        {
            Attack();
            turret.DrawLaser(turret.player.position);
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
