using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwing : MonoBehaviour
{
    public float playerDamage = 1f;
    public HealthPlayer hpscript;
    private bool ableToHitPlayer;
    internal bool hittingPlayer;
    public AIController aIController;

    private void Start()
    {
        hittingPlayer = false;
        aIController = GetComponent<AIController>();
    }
    private void OnCollisionEnter (Collision other)
    {
        HealthPlayer target = other.gameObject.GetComponent<HealthPlayer>();
    
        Debug.Log("hij collide");

        if (target == null)
        {
            Debug.Log("target is null");
        }

        if (other.gameObject.tag == "Player")
        {
            hittingPlayer = true;
          
            if (ableToHitPlayer == true)
            {
                ableToHitPlayer = false;
            }
            if (aIController.isAttacking)
            {
                target.TakeDamage(1);
                Debug.Log(target.playerHealth);
            }
        }
        
    }
}
