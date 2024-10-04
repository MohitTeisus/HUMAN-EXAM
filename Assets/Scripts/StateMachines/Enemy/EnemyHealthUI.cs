using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private EnemyHealth health;
    [SerializeField] private Transform healthBar;
    [SerializeField] private Image healthUI;

    private void FixedUpdate()
    {
        //makes the HP bar face the player
        if(Camera.main == null) return;

        healthBar.LookAt(Camera.main.transform);
    }

    private void OnEnable()
    {
        health.onHealthUpdate += UpdateHealthUI;
    }

    private void OnDisable()
    {
        health.onHealthUpdate -= UpdateHealthUI;
    }

    private void UpdateHealthUI(float health, float maxHealth)
    {
        healthUI.fillAmount -= health/maxHealth;
    }
}
