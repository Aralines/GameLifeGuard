using System;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private Animator _animator;
    private const string EXITCONTROL = "ExitControl";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool(EXITCONTROL, true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _animator.SetBool(EXITCONTROL, false);
    }
    
}
