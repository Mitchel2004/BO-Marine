using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwing : MonoBehaviour
{
    public float playerDamage = 1f;
    public HealthPlayer healthPlayer;
    public CapsuleCollider capsuleCollider;

    private GameObject playerRef;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;

        GameObject[] _player = FindObjectsOfType<GameObject>();

        foreach(GameObject gameobjectToCheck in _player)
        {
            if (gameobjectToCheck.transform.root.CompareTag("Player"))
            {
                playerRef = gameobjectToCheck.transform.root.gameObject;
                break;
            }
        }

        if(playerRef != null)
        {
            healthPlayer = playerRef.GetComponent<HealthPlayer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            healthPlayer.TakeDamage(playerDamage);
            Debug.Log("Player gets damage");
        }
    }

    IEnumerator DisableColliderAfterSeconds(float secondstowait)
    {
        yield return new WaitForSeconds(secondstowait);
        capsuleCollider.enabled = false;
        StopCoroutine("DisableColliderAfterSeconds");
    }

    public void EnableArmCollider(float lengthToEnableFor)
    {
        capsuleCollider.enabled = true;
        StartCoroutine("DisableColliderAfterSeconds", lengthToEnableFor);
    }
}
