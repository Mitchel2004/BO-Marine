using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    public Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvroked = false;

    //AI geeft damage aan de speler
    public float playerDamage = 100f;

    //hit the player with AI
    private bool ableToHit;
    internal bool hit;
    private object traget;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvroked)
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
        GetComponent<Animator>().SetTrigger("Walking");
        agent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log(name + " has seeked and is destroying " + target.name);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        target target = other.transform.GetComponent<target>();
        if (other.gameObject.tag == "enemy")
        {
            hit = true;
           
            if (ableToHit == true)
            {
                ableToHit = false;
            }
            target.takeDamage(playerDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
