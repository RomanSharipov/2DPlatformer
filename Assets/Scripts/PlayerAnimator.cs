using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerOptions))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;
    private PlayerOptions _playerOptions;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _playerOptions = GetComponent<PlayerOptions>();
    }

    public void Walk(float horizontal)
    {
        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        _animator.SetBool("IsGrounded", _playerOptions.IsGrounded);
    }
}
