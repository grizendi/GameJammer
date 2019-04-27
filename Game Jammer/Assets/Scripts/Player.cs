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

    [Tooltip("Time between shots (in seconds)")]
    [SerializeField] private float _boostCooldown = 1f;

    [Tooltip("Boost Power")]
    [SerializeField] private float _boostPower = 10f;

    [Tooltip("Boost Duration")]
    [SerializeField] private float _boostDuration = 0.5f;

    //component references
    private Rigidbody _rigidbody;
    private Weapon _weapon;

    //input variables
    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;
    private bool _fireInput = false;
    private bool _boostInput = false;
    private float _lastBoostTime = 0f;
    private float _boostMultiplier = 1f;
    

    private bool _canRotate = true;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;

        _weapon = GetComponent<Weapon>();

    }


    private void Update()
    {
        InputDevice inputDevice = (InputManager.Devices.Count > (_playerNumber - 1)) ? InputManager.Devices[_playerNumber - 1] : null;

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
        _boostInput = inputDevice.Action2;

        if (_fireInput)
        {
            _weapon.TryFire();
        }

        if (_boostInput)
        {
            // attempt to boost
            TryBoost();         
        }

    }

    private void TryBoost()
    {
        // can we boost?
        if (Time.timeSinceLevelLoad >= _lastBoostTime + _boostCooldown)
        {
            _lastBoostTime = Time.timeSinceLevelLoad;
            Boost();
        }    
    }

    private void Boost()
    {
        StartCoroutine(Booster());
    }

    IEnumerator Booster()
    {
        _canRotate = false;
        _boostMultiplier = _boostPower;
        yield return new WaitForSeconds(_boostDuration);
        _boostMultiplier = 1f;
        _canRotate = true;
    }
   
    private void FixedUpdate()
    {
        ThrustForward();
        Rotate();   
    }

    private void Rotate()
    {
         if(_canRotate)
        transform.Rotate(0f, _horizontalInput * _rotateSpeed, 0f);

      

    }

    private void ThrustForward()
    {
        _rigidbody.velocity = transform.forward * _forwardSpeed * _boostMultiplier;
    }
}
