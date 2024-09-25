using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyState
{
    float distanceToPlayer;

    public EnemyFollowState(EnemyController enemy) : base(enemy)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Enemy will start following the player");
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy will stop following the player");
    }

    public override void OnStateUpdate()
    {
        if (enemy.player != null)
        {
            distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.position);

            if (distanceToPlayer > 10)
            {
                //Going back to Idle
                enemy.ChangeState(new EnemyIdleState(enemy));
            }

            //Set attack
            if (distanceToPlayer < 3)
            {
                //Going to attack state
                enemy.ChangeState(new EnemyAttackState(enemy));
            }

            enemy.agent.destination = enemy.player.position;
        }
        else
        {
            //Going back to Idle
            enemy.ChangeState(new EnemyIdleState(enemy));
        }
    }
}
