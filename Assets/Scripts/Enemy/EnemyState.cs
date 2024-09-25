using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : BaseState
{
    protected EnemyController enemy;

    public EnemyState(EnemyController _enemy)
    {
        this.enemy = _enemy;
    }
}
