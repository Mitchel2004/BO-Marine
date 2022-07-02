using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSideEnemy : MonoBehaviour
{
    public Animator sideBossAnimator;
    public GameObject healthBar;
    public Transform player;

    public float sideEnemyHealth = 3f;

    float playerDistance;
    public Animator sideBossHealthbarAnimator;
    public SideAIController sideAIController;

    private bool Side_EnemyhealthbaranimatorOverride = false;
    public void TakeDamage(float amount)
    {
        sideEnemyHealth -= amount;

        if (sideEnemyHealth == 2f)
        {
            sideBossHealthbarAnimator.SetTrigger("HighToMedium");
        }
        else if (sideEnemyHealth == 1f)
        {
            sideBossHealthbarAnimator.SetTrigger("MediumToLow");
        }
        else
        {
            sideAIController.SetIsDead(true);
            sideBossAnimator.StopPlayback();
            sideBossAnimator.Play("Base Layer.Death", 0, 0f);
            Side_EnemyhealthbaranimatorOverride = true;
            healthBar.SetActive(false);
        }
    }
}
