using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _velocity = 10;

    [SerializeField] private float _lifetime;
    private Rigidbody _rigidboy;

    private void Start()
    {
        //set the initial velocity of projectile
        _rigidboy = GetComponent<Rigidbody>();
        _rigidboy.velocity = transform.forward * _velocity;

        // destroy projectile after ligetime
        Destroy(gameObject, _lifetime);
    }
}
