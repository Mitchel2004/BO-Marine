using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistTalk : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] talkAudio = new AudioClip[9];
    public GameObject scientistUI;
    public Camera mainCamera;
    public PlayerMovement movement;

    bool canTalk = true;
    float talkRange = 15f;
    float playerDistance;
    int clipIndex = 0;

    void Update()
    {
        scientistUI.transform.rotation = mainCamera.transform.rotation;

        playerDistance = Vector3.Distance(transform.position, scientistUI.transform.position);

        if (playerDistance <= talkRange && canTalk)
        {
            scientistUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
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

        audioSource.clip = talkAudio[clipIndex];
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        clipIndex += 1;

        canTalk = true;
        movement.enabled = true;
    }
}
