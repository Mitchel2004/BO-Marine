
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTarget : MonoBehaviour
{
    public float Sidehealth = 7f;
    [SerializeField] Animator Sideanimator;
    public SideAIController sideAIController;

    private void Update()
    {
        if (Sidehealth <= 0f)
        {
            Sideanimator.SetTrigger("Death");
            sideAIController.enabled = false;
        }
    }
}