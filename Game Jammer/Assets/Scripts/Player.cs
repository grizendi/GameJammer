using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _playerNumber = 1;
    [SerializeField] private float _forwardSpeed = 10f;

    private Rigidbody _rigidBody;
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.useGravity = false;
    }


    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal_P" + _playerNumber);
        _verticalInput = Input.GetAxis("Vertical_P" + _playerNumber);

    }

    private void FixedUpdate()
    {
        ThrustForward();
    }

    private void ThrustForward()
    {
        _rigidBody.velocity = transform.forward * _forwardSpeed;
    }
}
