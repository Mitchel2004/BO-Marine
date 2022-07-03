using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    [SerializeField] ParticleSystem particlesystem;
    [SerializeField] AudioSource audioSource;
    public Animator animator;
    public float PunchDamage = 1f;

    private BoxCollider collider;

    public HealthBoss healthBoss;

    private float punchLength = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particlesystem.Stop();
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(animator);
            animator.SetTrigger("Punch");
            collider.enabled = true;
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
            Debug.Log("Enemy get's damage :(");
        }
    }

    IEnumerator DisableColliderAfterSeconds(float secondstowait)
    {
        yield return new WaitForSeconds(secondstowait);
        collider.enabled = false;
    }

}