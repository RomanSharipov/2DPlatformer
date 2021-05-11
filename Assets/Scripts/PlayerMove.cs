using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerOptions))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private Animator _animator;
    private PlayerOptions _playerOptions;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerOptions = GetComponent<PlayerOptions>();
    }

    private void Update()
    {
        _direction = new Vector2(_playerInput.Horizontal, 0);
        RotateDirectionOfMove();
    }

    private void FixedUpdate()
    {
        if (_playerOptions.IsGrounded && _playerInput.Jump) 
        {
            Jump();
        }
        Move(_playerOptions.IsGrounded);
    }

    private void Run()
    {
        _rigidbody.velocity = _direction * _playerOptions.Speed + Vector2.up * _rigidbody.velocity.y;
        _animator.SetFloat("Horizontal", Mathf.Abs(_playerInput.Horizontal));
    }

    private void RotateDirectionOfMove()
    {
        if (_playerInput.Horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (_playerInput.Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _playerOptions.ForceJump, ForceMode2D.Impulse);
    }

    private void Move(bool IsGrounded)
    {
        _animator.SetBool("IsGrounded", IsGrounded);
        Run();
    }
}
