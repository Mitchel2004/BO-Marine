using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    [Header("Range")]
    [SerializeField] float chaseRange = 5f;

    [Header("Transforms")]
    public Transform target;

    [Header("Speeds")]
    [SerializeField] float turnSpeed = 5f;

    public bool isAttacking = false;
    //hit the player with AI
    internal bool hit;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvroked = false;
    public bool isDead = false;

    private enemySwing enemySwing;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        enemySwing = GetComponentInChildren<enemySwing>();

        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            Debug.Log("agent is null");
        }
    }
    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvroked && !isDead)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
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
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetBool("Walking", true);
        agent.SetDestination(target.position);
    }
    void AttackTarget()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            if(agent.remainingDistance < 6.1f)
            {
                GetComponent<Animator>().SetBool("Walking", false);
                GetComponent<Animator>().SetTrigger("Attack");
                isAttacking = true;
                enemySwing.EnableArmCollider(3f);
            }
           
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void SetIsDead(bool newIsDead)
    {
        isDead = newIsDead;
    }
}
