using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 1;               // Damage Dealth
    [SerializeField] private float _explosionForce = 1.5f;  //explosion force added at collision
    [SerializeField] private float _explosionRadius = 1f;
    

    private void OnCollisionEnter(Collision other)
    {
        // check if the other object has a health componen, and damage it if it exists
        other.gameObject.GetComponent<Health>()?.Damage(_damage);
        other.gameObject.GetComponent<Rigidbody>()?.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

    }


}


