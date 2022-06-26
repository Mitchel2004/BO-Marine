using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioTrigger : MonoBehaviour
{
    public Image canvas;

    private void Start()
    {
        canvas.enabled = false;
        Debug.Log("noStart");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.enabled = true;
        }
        Debug.Log("yes");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.enabled = false;
        }
        Debug.Log("no");
    }
}
