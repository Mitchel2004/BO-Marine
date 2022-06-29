
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 7f;
    [SerializeField] Animator animator;
    public AIController aIController;

    private void Update()
    {
        if (health <= 0f)
        {
            animator.SetTrigger("Death");
            aIController.enabled = false;
        }
    }
}