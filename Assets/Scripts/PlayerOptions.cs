using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOptions : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _distanceToGround;
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private int _countCoin;

    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float ForceJump { get; private set; }

    private bool CheckIsGroundedFoot(Transform foot)
    {
        return Physics2D.Raycast(foot.position, -foot.up, _distanceToGround, _ground);
    }

    public bool CheckIsGrounded()
    {
        return CheckIsGroundedFoot(_leftFoot) || CheckIsGroundedFoot(_rightFoot);
    }

    public void AddCoin()
    {
        _countCoin++;
    }
}
