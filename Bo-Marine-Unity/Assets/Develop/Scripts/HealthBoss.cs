using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBoss : MonoBehaviour
{
    public Animator bossAnimator;
    public Animator bosshealthbarAnimator;
    public GameObject healthBar;
    public Transform player;

    public float bossHealth = 3f;
    float healthBarRange = 45f;
    float playerDistance;

    [SerializeField]
    Sprite emptyHealthbar;

    public AIController aIController;

    private bool bosshealthbaranimatorOverride = false;
 
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
            aIController.SetIsDead(true);
            bossAnimator.StopPlayback();
            bossAnimator.Play("Base Layer.Death",0,0f);
            bosshealthbaranimatorOverride = true;
            healthBar.SetActive(false);
        }
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance <= healthBarRange)
        {
            if (!bosshealthbaranimatorOverride)
            {
                healthBar.SetActive(true);
            }
        }
        else
        {
            healthBar.SetActive(false);
        }
    }
}
