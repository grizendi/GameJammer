using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [Tooltip("This ship represents player number...")]
    [SerializeField] private int _playerNumber = 1;

    [Tooltip("Speed of the plane")]
    [SerializeField] private float _forwardSpeed = 10f;

    [Tooltip("Rotate speed")]
    [SerializeField] private float _rotateSpeed = 10f;

    private Rigidbody _rigidbody;
    private Weapon _weapon;
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;
    private bool _fireInput = false;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;

        _weapon = GetComponent<Weapon>();

    }


    private void Update()
    {
        var inputDevice = (InputManager.Devices.Count > (_playerNumber - 1)) ? InputManager.Devices[_playerNumber - 1] : null;

        if (inputDevice == null)
        {
            Debug.LogError("No controller is attached for player " + _playerNumber);
        }
        else
        {
            ProcessInput(inputDevice);
        }

    }

    private void ProcessInput(InputDevice inputDevice)
    {
        //movement input
        _horizontalInput = inputDevice.Direction.X;
        _verticalInput = inputDevice.Direction.Y;

        _fireInput = inputDevice.Action1;

        if (_fireInput)
        {
            _weapon.TryFire();
        }

    }


    private void FixedUpdate()
    {
        ThrustForward();
        Rotate();
       
    }

    private void Rotate()
    {
        transform.Rotate(0f, _horizontalInput * _rotateSpeed, 0f);

    }

    private void ThrustForward()
    {
        _rigidbody.velocity = transform.forward * _forwardSpeed;
    }
}
