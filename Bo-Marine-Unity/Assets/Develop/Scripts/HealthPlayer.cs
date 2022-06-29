using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator playerhealthbarAnimator;
    public GameObject healthBar;

    public float playerHealth = 3f;

    public Animator enemyAnimator;
    public enemySwing enemySwing;
    public Collider enemyHandCollider;
    public PlayerMovement playerMovement;
    public CameraMovement cameraMovement;
    public void TakeDamage(float amount)
    {
        playerHealth -= amount;

        if (playerHealth == 2f)
        {
            playerhealthbarAnimator.SetTrigger("HighToMedium");
        }
        else if (playerHealth == 1f)
        {
            playerhealthbarAnimator.SetTrigger("MediumToLow");
        }
        else
        {
            playerAnimator.SetTrigger("Dead");
            playerhealthbarAnimator.SetTrigger("Exit");

            enemyHandCollider.enabled = false;
            enemyAnimator.enabled = false;
            enemySwing.enabled = false;
            playerMovement.enabled = false;
            cameraMovement.enabled = false;
            

            healthBar.SetActive(false);
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
