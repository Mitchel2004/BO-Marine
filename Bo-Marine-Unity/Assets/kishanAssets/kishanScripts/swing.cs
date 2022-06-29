using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    [SerializeField] ParticleSystem particlesystem;
    [SerializeField] AudioSource audioSource;
    public Animator animator;
    public float PunchDamage = 1f;

    public HealthBoss healthBoss;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particlesystem.Stop();    
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(animator);
            animator.SetTrigger("Punch");
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        audioSource.Play(0);
        Debug.Log("Collider works of the player");

        if (other.gameObject.tag == "enemy")
        {
            particlesystem.Play();
            healthBoss.TakeDamage(PunchDamage);
            Debug.Log("Enemy get's damage :(");
        }
    }
}