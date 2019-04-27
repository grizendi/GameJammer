using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [Tooltip("This ship represents player number...")]
    [SerializeField] private int _playerNumber = 1;

    [Tooltip("Speed of the plane")]
    [SerializeField] private float _forwardSpeed = 10f;

    [SerializeField] private float _rotateSpeed = 10f;

    private Rigidbody _rigidBody;
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;
    private bool _fireInput = false;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.useGravity = false;
    }


    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal_P" + _playerNumber);
        _verticalInput = Input.GetAxis("Vertical_P" + _playerNumber);
        _fireInput = Input.GetButtonDown("Fire1_P" + _playerNumber);

    }

    private void FixedUpdate()
    {
        ThrustForward();
        Rotate();
    }

    private void Rotate()
    {
        //Vector3 direction = new Vector3(0f, _horizontalInput, 0f);
        transform.Rotate(0f, _horizontalInput * _rotateSpeed, 0f);
    }

    private void ThrustForward()
    {
        _rigidBody.velocity = transform.forward * _forwardSpeed;
    }
}
