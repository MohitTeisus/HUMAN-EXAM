using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyController[] enemies;

    public void RespawnEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.Respawn();
        }
    }
}
