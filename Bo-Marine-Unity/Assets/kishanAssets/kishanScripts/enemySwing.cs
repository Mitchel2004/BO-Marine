using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwing : MonoBehaviour
{
    public float playerDamage = 1f;
    public HealthPlayer healthPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthPlayer.TakeDamage(playerDamage);
            Debug.Log("Player get's damage");
        }
    }
}
