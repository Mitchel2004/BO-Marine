using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public target hpscript;
    [SerializeField] ParticleSystem particlesystem;
    internal bool hit;
    public Animator animator;
    private bool ableToHit;
    public float PunchDamage = 1f;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        ableToHit = true; 
        hit = false;
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

    private void OnCollisionEnter (Collision other)
    {
        audioSource.Play(0);
        target target = other.gameObject.GetComponent<target>();
        target.health -= PunchDamage;
        Debug.Log("hij collide");
        if (target == null)
        {
            Debug.Log("target is null");
        }

        if (other.gameObject.tag == "enemy")
        {
            hit = true;
            particlesystem.Play();
            if (ableToHit == true)
            {
                ableToHit = false;
            }
            target.health -= PunchDamage;
            Debug.Log(target.health);
        }
    }
}