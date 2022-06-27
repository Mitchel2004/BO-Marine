using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearCamp : MonoBehaviour
{
    public Transform campPoint;
    public AudioSource audioSource;
    public AudioClip[] radioAudio = new AudioClip[1];
    public GameObject radio;
    public GameObject[] text = new GameObject[2];

    float campRange = 25f;
    float playerDistance;
    bool canTalk = true;
    int clipIndex = 0;

    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, campPoint.position);

        if (playerDistance <= campRange && canTalk)
        {
            StartCoroutine(Radio());
        }
    }

    IEnumerator Radio()
    {
        canTalk = false;

        if (clipIndex == 0)
        {
            audioSource.clip = radioAudio[0];
            audioSource.Play();
            StartCoroutine(Text());

            yield return new WaitForSeconds(audioSource.clip.length);

            canTalk = true;
            clipIndex = 1;
        }
    }

    IEnumerator Text()
    {
        radio.SetActive(true);
        text[0].SetActive(true);

        yield return new WaitForSeconds(8f);

        text[0].SetActive(false);
        text[1].SetActive(true);

        yield return new WaitForSeconds(4f);

        text[1].SetActive(false);
        radio.SetActive(false);
    }
}
