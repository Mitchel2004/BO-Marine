using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public float playerHealth = 5000f;
    public Transform target;
    public void takeDamage(float amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
