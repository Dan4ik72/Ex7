using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Animator))]
public class Boar : MonoBehaviour
{
    private readonly int _isWalkingParameterHash = Animator.StringToHash("IsWalking"); 

    private Patrol _patrol;
    private Animator _animator;
    
    private void Start()
    {
        _patrol = GetComponent<Patrol>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_isWalkingParameterHash, _patrol.IsWalking);
    }
}
