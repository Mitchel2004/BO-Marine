using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public target damagescript;
    Collision collision;
    [SerializeField] ParticleSystem particlesystem;
    internal bool hit;
    [SerializeField] Animator animator;
    private bool ableToHit;
    public float PunchDamage = 1f;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        ableToHit = true;
        animator = GetComponent<Animator>();
        hit = false;
        particlesystem.Stop();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Punch");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play(0);
        target target = other.transform.GetComponent<target>();
        if (other.gameObject.tag == "enemy")
        {
            hit = true;
            particlesystem.Play();
            if (ableToHit == true)
            {
                ableToHit = false;
            }
            target.health -= PunchDamage;
            // target.takeDamage(PunchDamage);
        }
    }
}