using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : BaseState
{
    protected EnemyStateController enemy;

    public EnemyState(EnemyStateController _enemy)
    {
        this.enemy = _enemy;
    }
}
