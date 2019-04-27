using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Tooltip("The projectile to be fired")]
    [SerializeField] protected GameObject _projectilePrefab;

    [Tooltip("Time between shots (in seconds)")]
    [SerializeField] private float _fireCooldown = 1f;       

    private float _lastFireTime;                                // the time when we last fired

    // attempt to fire the weapon
    public void TryFire()
    {
        // can we fire?
        if (Time.timeSinceLevelLoad >= _lastFireTime + _fireCooldown)
        {
            _lastFireTime = Time.timeSinceLevelLoad;
            Fire();
        }
    }

    // fire the weapon
    protected virtual void Fire()
    {
        Instantiate(_projectilePrefab, transform.position, transform.rotation);
    }
}
