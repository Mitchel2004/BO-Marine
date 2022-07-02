using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SideAIController : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    public Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] Animator animator;

    //Damage for the player
    internal bool hit;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvroked = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            Debug.Log("agent is null");
        }
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvroked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvroked = true;
        }
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= agent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= agent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Run");
        agent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            if (agent.remainingDistance < 6.1f)
            {
                animator.SetTrigger("Run");
                animator.SetBool("Attack", false);
            }
        }  
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
