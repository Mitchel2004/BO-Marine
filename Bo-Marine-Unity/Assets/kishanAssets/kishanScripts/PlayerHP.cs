using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float health = 50f;
    [SerializeField] Animator animator;

    private void Update()
    {
        if (health <= 0f)
        {
            animator.SetTrigger("Dead");
        }
    }
}
