using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwing : MonoBehaviour
{
    public float playerDamage = 10f;
    public PlayerHP hpscript;
    private void OnCollisionEnter(Collision other)
    {
        PlayerHP target = other.gameObject.GetComponent<PlayerHP>();
        if (target == null)
        {
            Debug.Log("target is null");
        }

        if (other.gameObject.tag == "Player")
        {
            target.health -= playerDamage;
            Debug.Log(target.health);
        }
    }
}
