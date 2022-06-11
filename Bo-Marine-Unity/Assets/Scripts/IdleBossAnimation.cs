using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossAnimation : MonoBehaviour
{
    [Header("States animation")]
    Animator _animator;
    GameObject Player;
    private bool _collideWithPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            _animator.SetBool("Idle", true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == Player)
        {
            _collideWithPlayer = true;
        }  
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == Player)
        {
            _collideWithPlayer = false;
        }      
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            _animator.SetBool("Idle", false);
        }   
    }
    void Attack()
    {
        if (_collideWithPlayer)
        {
            print("player has been hit");
        }
    }
}
