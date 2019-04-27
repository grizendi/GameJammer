using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Projectile : MonoBehaviour
{
    [Tooltip("The Initial Velocity")]
    [SerializeField] private float _velocity = 100f;
    
    [Tooltip("Life time duration (in seconds)")]
    [SerializeField] private float _lifeTime = 10f;       // life time duration (seconds)

    private Rigidbody _rigidbody;

    private void Start()
    {
        // set the initial velocity of the projectile
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * _velocity;

        // destroy the projectile after _lifeTime
        Destroy(gameObject, _lifeTime);
    }

}
