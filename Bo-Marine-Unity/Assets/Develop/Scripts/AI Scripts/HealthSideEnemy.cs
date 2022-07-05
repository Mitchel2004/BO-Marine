using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSideEnemy : MonoBehaviour
{
    [Header("Damage")]
    public float sideEnemyHealth = 3f;
    public float sideEnemydamage = 1f;

    [Header("Animator")]
    public Animator sideEnemyAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sideEnemyHealth -= sideEnemydamage;
        }
    }




    /*public Animator sideBossAnimator;
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
    }*/
}
