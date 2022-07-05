using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SideAIController : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;

    public Transform target;

    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent agent;

    float distanceToTarget = Mathf.Infinity;

    bool isProvroked = false;
    public bool isDead = false;
    public bool isAttacking = false;

    private SideEnemySwing sideEnemySwing;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        sideEnemySwing = GetComponentInChildren<SideEnemySwing>();

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
        GetComponent<Animator>().SetBool("Run", true);
        agent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            if (agent.remainingDistance < 5.1f)
            {
                GetComponent<Animator>().SetBool("Run", false);
                GetComponent<Animator>().SetTrigger("Attack_Hit");
                isAttacking = true;
                sideEnemySwing.Side_EnableArmCollider(3f);
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
    public void SetIsDead(bool newIsDead)
    {
        isDead = newIsDead;
    }
}
