using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    [SerializeField] ParticleSystem particlesystem;
    [SerializeField] AudioSource audioSource;
    public Animator animator;
    public float PunchDamage = 1f;

    private BoxCollider boxCollider;

    public HealthBoss healthBoss;
    public HealthSideEnemy healthSide;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particlesystem.Stop();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(animator);
            animator.SetTrigger("Punch");
            boxCollider.enabled = true;
            Invoke("DisableColliderAfterSeconds", 0f);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        audioSource.Play(0);
        Debug.Log("Collider works of the player");

        if (other.gameObject.transform.root.CompareTag("enemy"))
        {
            particlesystem.Play();
            healthBoss.TakeDamage(PunchDamage);
            other.gameObject.GetComponent<HealthSideEnemy>().TakeDamage(PunchDamage);
            Debug.Log("Enemy gets damage");
        }
    }

    IEnumerator DisableColliderAfterSeconds(float secondstowait)
    {
        yield return new WaitForSeconds(secondstowait);
        boxCollider.enabled = false;
    }
}