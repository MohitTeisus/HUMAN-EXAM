using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    float distanceToPlayer;
    PlayerHealth playerHealth;

    public EnemyAttackState(EnemyStateController enemy) : base(enemy)
    {
        playerHealth = base.enemy.player.GetComponent<PlayerHealth>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enemy will attack the Player");
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy will stop attacking the player");
    }

    public override void OnStateUpdate()
    {
        Attack();

        if (enemy.player != null)
        {
            distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.position);

            if (distanceToPlayer > 3)
            {
                //Going to follow state
                enemy.ChangeState(new EnemyFollowState(enemy));
            }

            
            enemy.agent.destination = enemy.player.position;
        }
        else
        {
            //Going back to Idle
            enemy.ChangeState(new EnemyIdleState(enemy));
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.DeductHealth(enemy.damagePerSecond * Time.deltaTime);
        }
    }
}
