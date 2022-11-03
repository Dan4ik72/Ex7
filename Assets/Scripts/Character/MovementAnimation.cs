using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]
public class MovementAnimation : MonoBehaviour
{
    private readonly int _isRunningParameterHash = Animator.StringToHash("IsRunning");
    private readonly int _isOnGroundParameterHash = Animator.StringToHash("IsOnGround");

    private Movement _movement;
    private Animator _animator;    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        PlayRunAnimation();        
    }
    
    public void PlayLandAnimation()
    {
        _animator.SetBool(_isOnGroundParameterHash, true);
    }

    public void PlayJumpAnimation()
    {
        _animator.SetBool(_isOnGroundParameterHash, false);
    }

    private void PlayRunAnimation()
    {
        _animator.SetBool(_isRunningParameterHash, _movement.IsRunning);
    }
}
