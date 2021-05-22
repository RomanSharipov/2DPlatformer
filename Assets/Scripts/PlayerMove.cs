using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerOptions))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerOptions _playerOptions;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerOptions = GetComponent<PlayerOptions>();
    }

    public void Walk(float horizontal)
    {
        _rigidbody.velocity = new Vector2(horizontal, 0) * _playerOptions.Speed + Vector2.up * _rigidbody.velocity.y;
    }

    public void RotateDirectionOfMove(float horizontal)
    {
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Jump()
    {
        if (_playerOptions.CheckIsGrounded())
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _playerOptions.ForceJump, ForceMode2D.Impulse);
        }
    }
}
