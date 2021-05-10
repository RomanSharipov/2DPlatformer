using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _forceJump = 8;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _distanceToGround;
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private int _countCoin;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private float _inputHorizontal;
    private Animator _animator;
    private Collider2D _collider2D;
    private bool _isGroundedLeftFoot;
    private bool _isGroundedRightFoot;

    private void Start()
    {
        _countCoin = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _direction = new Vector2(_inputHorizontal, 0);
        RotateDirectionOfMove();
    }

    private void FixedUpdate()
    {
        _isGrounded = CheckIsGrounded(_leftFoot) || CheckIsGrounded(_rightFoot);

        if (_isGrounded && Input.GetKey(KeyCode.Space)) 
        {
            Jump();
        }

        Move(_isGrounded);
    }

    private void Run()
    {
        _rigidbody.velocity = _direction * _speed + Vector2.up * _rigidbody.velocity.y;
        _animator.SetFloat("Horizontal", Mathf.Abs( _inputHorizontal));
    }

    private void RotateDirectionOfMove()
    {
        if (_inputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (_inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
    }

    private void Move(bool IsGrounded)
    {
        _animator.SetBool("IsGrounded", IsGrounded);
        Run();
    }

    private bool CheckIsGrounded(Transform foot)
    {
        return Physics2D.Raycast(foot.position, -foot.up, _distanceToGround, _ground);
    }

    public void AddCoin()
    {
        _countCoin++;
    }
}
