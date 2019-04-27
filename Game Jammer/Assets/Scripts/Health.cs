using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 3;                // our current health
    [SerializeField] private GameObject _deathParticles;            // gameObject to spawn on death
    [SerializeField] private float _deathParticlesDuration = 1f;    // duration of death particles
    [SerializeField] private int _scoreValue = 0;                   // points awarded on death

    private int _maxHealth;                                         // our max health

    // return the current health percentage
    public float CurrentHealthPercentage => (float)_currentHealth / _maxHealth;

    // death event
    [SerializeField] private UnityEvent DeathEvent;

    private void Start()
    {
        // set max health
        _maxHealth = _currentHealth;
    }

    // deal damage
    public void Damage(int amount)
    {
        // lower our current health
        _currentHealth -= amount;

        // check to see if we're still alive
        if (_currentHealth <= 0)
        {
            Death();
        }
    }
    
    
    // handle death
    private void Death()
    {
        // spawn death particles, if they exist
        if (_deathParticles != null)
        {
            // instantiate and destroy death particles
            Destroy(Instantiate(_deathParticles, transform.position, transform.rotation), _deathParticlesDuration);
        }

        // add score on death
    //    Score.AddScore(_scoreValue);

        // invoke death event
        DeathEvent.Invoke();

        Destroy(gameObject);
    }

}
