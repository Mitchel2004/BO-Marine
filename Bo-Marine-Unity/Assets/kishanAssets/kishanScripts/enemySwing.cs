using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwing : MonoBehaviour
{
    public float playerDamage = 10f;
    public PlayerHP hpscript;
    private void OnCollisionEnter(Collision other)
    {
        target target = other.gameObject.GetComponent<target>();
        if (target == null)
        {
            Debug.Log("target is null");
        }

        if (other.gameObject.tag == "enemy")
        {
            target.health -= playerDamage;
            Debug.Log(target.health);
        }
    }
}
