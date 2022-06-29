using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public Animator bossAnimator;
    public Animator bosshealthbarAnimator;
    public GameObject healthBar;
    public Transform player;

    public float bossHealth = 3f;
    float healthBarRange = 45f;
    float playerDistance;

    public AIController aIController;
 
    public void TakeDamage(float amount)
    {
        bossHealth -= amount;

        if (bossHealth == 2f)
        {
            bosshealthbarAnimator.SetTrigger("HighToMedium");
        }
        else if (bossHealth == 1f)
        {
            bosshealthbarAnimator.SetTrigger("MediumToLow");
        }
        else 
        {
            bossAnimator.SetTrigger("Death");
            bosshealthbarAnimator.SetTrigger("Exit");
            aIController.enabled = false;
            healthBar.SetActive(false);
            Debug.Log("WHAHAHA ik leef voor eeuwig :))");
        }
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance <= healthBarRange)
        {
            healthBar.SetActive(true);
        }
        else
        {
            healthBar.SetActive(false);
        }
    }
}
