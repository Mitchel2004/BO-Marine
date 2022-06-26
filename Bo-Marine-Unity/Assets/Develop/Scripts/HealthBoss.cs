using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    public Animator bossAnimator;
    public Animator healthAnimator;
    public GameObject healthBar;
    public Transform player;

    public float bossHealth = 3f;
    float healthBarRange = 25f;
    float playerDistance;
    public Transform target;

    public void TakeDamage(float amount)
    {
        bossHealth -= amount;

        if (bossHealth == 2f)
        {
            healthAnimator.SetTrigger("HighToMedium");
        }
        else if (bossHealth == 1f)
        {
            healthAnimator.SetTrigger("MediumToLow");
        }
        else
        {
            bossAnimator.SetTrigger("Dead");
            healthAnimator.SetTrigger("Exit");
            healthBar.SetActive(false);
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
