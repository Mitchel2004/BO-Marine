using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientistAni : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Transform player;
    [SerializeField] float Range = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance (player.transform.position, transform.position) <= Range && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("giveSample_Jump", true);
            animator.SetBool("giveSample_Jump", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
     

    
}
