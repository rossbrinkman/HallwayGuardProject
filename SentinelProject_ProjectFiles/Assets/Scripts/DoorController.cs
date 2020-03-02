using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour


{
    private Animator _animator;
  
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _animator.SetBool("open", true);
            GetComponent<AudioSource>().Play();
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _animator.SetBool("open", true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        _animator.SetBool("open", false);
    }

}


