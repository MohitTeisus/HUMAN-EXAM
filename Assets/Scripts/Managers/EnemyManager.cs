using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;

    public void RespawnEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.Respawn();
        }
    }
}
