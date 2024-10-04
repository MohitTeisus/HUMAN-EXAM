using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

            //if the enemy is close enough to the player it will stop moving, to prevent the enemy from pushing the player
            if(distanceToPlayer < 2)
            {
                enemy.agent.destination = enemy.transform.position;
            }
            else
            {
                enemy.agent.destination = enemy.player.position;
            }
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
