using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent _jump;
    [SerializeField] private MoveEvent _walk;

    private float _horizontal;

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");

        _walk.Invoke(_horizontal);

        if (Input.GetKey(KeyCode.Space))
        {
            _jump.Invoke();
        }
    }
}

[System.Serializable]
public class MoveEvent : UnityEvent<float> { }
