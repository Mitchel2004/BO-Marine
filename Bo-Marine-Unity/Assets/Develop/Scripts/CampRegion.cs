using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampRegion : MonoBehaviour
{
    public Transform campPoint;
    public AudioSource audioSource;
    public AudioClip[] radioAudio = new AudioClip[2];
    public GameObject radio;
    public GameObject[] text1 = new GameObject[5];
    public GameObject[] text2 = new GameObject[2];

    float campRange = 50f;
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
            StartCoroutine(Text1());

            yield return new WaitForSeconds(audioSource.clip.length);

            canTalk = true;
            clipIndex = 1;
        }
        else if (clipIndex == 1)
        {
            yield return new WaitForSeconds(2f);

            audioSource.clip = radioAudio[1];
            audioSource.Play();
            StartCoroutine(Text2());

            yield return new WaitForSeconds(audioSource.clip.length);

            canTalk = true;
            clipIndex = 2;
        }
    }

    IEnumerator Text1()
    {
        radio.SetActive(true);
        text1[0].SetActive(true);

        yield return new WaitForSeconds(8f);

        text1[0].SetActive(false);
        text1[1].SetActive(true);

        yield return new WaitForSeconds(6f);

        text1[1].SetActive(false);
        text1[2].SetActive(true);

        yield return new WaitForSeconds(10f);

        text1[2].SetActive(false);
        text1[3].SetActive(true);

        yield return new WaitForSeconds(8f);

        text1[3].SetActive(false);
        text1[4].SetActive(true);

        yield return new WaitForSeconds(4f);

        text1[4].SetActive(false);
        radio.SetActive(false);
    }

    IEnumerator Text2()
    {
        radio.SetActive(true);
        text2[0].SetActive(true);

        yield return new WaitForSeconds(6f);

        text2[0].SetActive(false);
        text2[1].SetActive(true);

        yield return new WaitForSeconds(4f);

        text2[1].SetActive(false);
        radio.SetActive(false);
    }
}
