using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerOptions))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerOptions _playerOptions;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerOptions = GetComponent<PlayerOptions>();
    }

    public void Walk(float horizontal)
    {
        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        _animator.SetBool("IsGrounded", _playerOptions.CheckIsGrounded());
    }
}
