using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public float playerHealth = 5000f;
    public Transform target;
    public void TakeDamage(float amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
