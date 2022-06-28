using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwing : MonoBehaviour
{
    public float playerDamage = 10f;
    public PlayerHP hpscript;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHP target = other.transform.GetComponent<PlayerHP>();
        if (other.gameObject.tag == "player")
        {
            target.health -= playerDamage;
            Debug.Log(target.health);
        }
    }
}
