using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSideEnemy : MonoBehaviour
{
    [SerializeField] public Slider healthBar;
    [SerializeField] public Gradient gradient;
    [SerializeField] public Image fill;

    public Animator sideEnemyAnimator;

    public Transform Player;
    public float sideEnemyHealthbar = 3f;

    public SideAIController sideAIController;

    public void TakeDamage(float amount)
    {
        sideEnemyHealthbar -= amount;

        if (amount == 0f)
        {
            sideEnemyAnimator.Play("Base Layer.Death", 0, 0f);
        }
    }

    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
