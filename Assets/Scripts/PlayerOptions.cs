using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptions : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _distanceToGround;
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private int _countCoin;

    [field: SerializeField] public float Speed { get;  private set; }
    [field: SerializeField] public float ForceJump { get; private set; }
    [field: SerializeField] public bool IsGrounded { get; private set; }

    void FixedUpdate()
    {
        IsGrounded = CheckIsGrounded(_leftFoot) || CheckIsGrounded(_rightFoot);
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
