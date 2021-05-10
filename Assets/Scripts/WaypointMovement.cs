using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private int _speed;
    [SerializeField] private float _distanceForAttack;
    [SerializeField] private LayerMask _player;
    [SerializeField] private bool _playerNearby;
    [SerializeField] private Animator _animator;

    private Transform[] _points;
    private int _currentPoint;
    private float _previousFramePosition;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void FixedUpdate()
    {
        _playerNearby = Physics2D.Raycast(transform.position, transform.right, _distanceForAttack, _player);
        if (_playerNearby == false)
        {
            MoveOnPoints();
        }
        else
        {
            Attack();
        }
    }

    private void SetRotation()
    {
        if (_previousFramePosition > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_previousFramePosition < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        _previousFramePosition = transform.position.x;
    }

    private void MoveOnPoints()
    {
        _animator.SetBool("Attack", false);
        Transform _target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        if (transform.position == _target.position)
        {
            _currentPoint++;
            if (_currentPoint == _points.Length)
            {
                _currentPoint = 0;
            }
        }
        SetRotation();
    }

    private void Attack()
    {
        _animator.SetBool("Attack",true);
    }
}
