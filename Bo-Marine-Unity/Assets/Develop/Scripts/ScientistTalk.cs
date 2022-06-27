using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistTalk : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] talkAudio = new AudioClip[4];
    public GameObject scientistUI;
    public Camera mainCamera;
    public PlayerMovement movement;
    public Animator playerAnimator;
    public Animator scientistAnimator;
    public HealthBoss boss;

    bool canTalk = true;
    float talkRange = 15f;
    float playerDistance;
    int clipIndex = 0;

    void Start()
    {
        InvokeRepeating("Scratch", 10f, 20f);
    }

    void Update()
    {
        scientistUI.transform.rotation = mainCamera.transform.rotation;

        playerDistance = Vector3.Distance(transform.position, scientistUI.transform.position);

        if (playerDistance <= talkRange && canTalk)
        {
            scientistUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerAnimator.SetFloat("Speed", 0f);
                StartCoroutine(Talk());
            }
        }
        else
        {
            scientistUI.SetActive(false);
        }
    }

    IEnumerator Talk()
    {
        canTalk = false;
        movement.enabled = false;

        if (clipIndex <= 1 && boss.bossHealth > 0f)
        {
            audioSource.clip = talkAudio[0];
            audioSource.Play();
            scientistAnimator.SetTrigger("Jump");

            yield return new WaitForSeconds(44f);

            scientistAnimator.SetTrigger("Thinking");

            yield return new WaitForSeconds(audioSource.clip.length - 44f);

            movement.enabled = true;
            canTalk = true;

            audioSource.clip = talkAudio[1];
            audioSource.Play();

            clipIndex = 2;
        }
        else if (boss.bossHealth > 0f)
        {
            audioSource.clip = talkAudio[2];
            audioSource.Play();

            yield return new WaitForSeconds(2f);

            scientistAnimator.SetTrigger("Head");

            yield return new WaitForSeconds(audioSource.clip.length - 2f);

            canTalk = true;
            movement.enabled = true;
        }
        else
        {
            audioSource.clip = talkAudio[3];
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

            canTalk = true;
            movement.enabled = true;
        }
    }

    void Scratch()
    {
        scientistAnimator.SetTrigger("Ass");
    }
}
