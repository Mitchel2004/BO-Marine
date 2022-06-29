using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator healthAnimator;
    public GameObject healthBar;
    
    public float playerHealth = 3f;
    public Transform target;

    public void TakeDamage(float amount)
    {
        playerHealth -= amount;
        
        if (playerHealth == 2f)
        {
            healthAnimator.SetTrigger("HighToMedium");
        }
        else if (playerHealth == 1f)
        {
            healthAnimator.SetTrigger("MediumToLow");
        }
        else
        {
            playerAnimator.SetTrigger("Dead");
            healthAnimator.SetTrigger("Exit");
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
