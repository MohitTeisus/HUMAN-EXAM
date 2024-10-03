using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private EnemyHealth health;
    [SerializeField] private Image healthUI;

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
