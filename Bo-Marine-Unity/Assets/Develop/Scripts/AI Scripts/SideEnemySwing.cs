using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEnemySwing : MonoBehaviour
{
    public float playerDamage_Side = 1f;
    public HealthPlayer healthPlayer_Side;
    public BoxCollider boxCollider;

    private GameObject Side_PlayerRef;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;

        GameObject[] _player = FindObjectsOfType<GameObject>();

        foreach (GameObject gameobjectToCheck in _player)
        {
            if (gameobjectToCheck.transform.root.CompareTag("Player"))
            {
                Side_PlayerRef = gameobjectToCheck.transform.root.gameObject;
                break;
            }
        }

        if (Side_PlayerRef != null)
        {
            healthPlayer_Side = Side_PlayerRef.GetComponent<HealthPlayer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            healthPlayer_Side.TakeDamage(playerDamage_Side);
            Debug.Log("Player gets damage Side");
        }
    }

    IEnumerator DisableColliderAfterSeconds(float secondstowait)
    {
        yield return new WaitForSeconds(secondstowait);
        boxCollider.enabled = false;
        StopCoroutine("DisableColliderAfterSeconds");
    }

    public void Side_EnableArmCollider(float lengthToEnableFor)
    {
        boxCollider.enabled = true;
        StartCoroutine("DisableColliderAfterSeconds", lengthToEnableFor);
    }
}