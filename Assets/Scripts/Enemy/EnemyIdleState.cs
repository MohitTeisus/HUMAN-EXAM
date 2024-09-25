using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    int currentTarget = 0;

    public EnemyIdleState(EnemyController enemy) : base(enemy)
    {

    }

    public override void OnStateEnter()
    {
        enemy.agent.destination = enemy.targetPoints[currentTarget].position;
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy Stopped Idling");
    }

    public override void OnStateUpdate()
    {
        if (enemy.agent.remainingDistance < 0.8f)
        {
            currentTarget++;
            if (currentTarget >= enemy.targetPoints.Length)
            {
                currentTarget = 0;
            }
            enemy.agent.destination = enemy.targetPoints[currentTarget].position;
        }

        if (Physics.SphereCast(enemy.enemyEye.position, enemy.checkRadius, enemy.transform.forward, out RaycastHit hit, enemy.playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found");
                enemy.player = hit.transform;
                enemy.agent.destination = enemy.player.position;

                //Move to a new State
                enemy.ChangeState(new EnemyFollowState(enemy));
            }
        }
    }
}
