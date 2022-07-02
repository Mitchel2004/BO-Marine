using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSideEnemy : MonoBehaviour
{
    public Animator sideBossAnimator;
    public Animator sideBossHealthbarAnimator;
    public GameObject healthBar;
    public Transform player;

    public float sideEnemyHealth = 3f;
    float healthBarRange = 45f;
    float playerDistance;

    [SerializeField]
    Sprite emptyHealthbar;

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

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance <= healthBarRange)
        {
            if (!Side_EnemyhealthbaranimatorOverride)
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
