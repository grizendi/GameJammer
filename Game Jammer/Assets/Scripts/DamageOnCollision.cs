using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 1;       // Damage Dealth

    private void OnCollisionEnter(Collision other)
    {
        // check if the other object has a health componen, and damage it if it exists
        other.gameObject.GetComponent<Health>()?.Damage(_damage);
    }


}


