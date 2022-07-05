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
    public SideAIController sideAI;

    private bool playerIsDead = false;

    public void Start()
    {
        GameObject[] _enemyFindArray = FindObjectsOfType<GameObject>();

        foreach (GameObject gameobjectToCheck in _enemyFindArray)
        {
            if (gameobjectToCheck.transform.root.CompareTag("enemy"))
            {
                GameObject _enemyRef = gameobjectToCheck.transform.root.gameObject;
                enemySwing = _enemyRef.GetComponentInChildren<enemySwing>();
                break;
            }
        }
    }


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
            if (!playerIsDead)
            {
                playerIsDead = true;
                playerAnimator.StopPlayback();
                playerAnimator.Play("Base Layer.Dead", 0, 0f);
                playerhealthbarAnimator.SetTrigger("Exit");

                enemyHandCollider.enabled = false;
                enemyAnimator.enabled = false;
                enemySwing.enabled = false;
                playerMovement.enabled = false;
                cameraMovement.enabled = false;
                sideAI.enabled = false;

                healthBar.SetActive(false);
                StartCoroutine(Restart());
            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
