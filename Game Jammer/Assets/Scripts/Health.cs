using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float _currentHealth = 10f;                        // amount of health the plane has
    [SerializeField] GameObject _deathParticle;                                 // particle effect attached 
    [SerializeField] private float _deathparticlesDuration = 1f;                // length of particl effect
    [SerializeField] private int _scoreValue = 0;                               // points awarded for killing other player

    private float _maxHealth;                    

    //return health as a percentage 
    public float CurrentHealthPercentage => (float)_currentHealth / _maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = _currentHealth;  
    }

    
    public void Damage(int _amount)
    {

        //lower health
        _currentHealth -= _amount;

        // check to see if plane is not destroyed

        if(_currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        
        if(_deathParticle != null)
        {
            Destroy(Instantiate(_deathParticle, transform.position, transform.rotation), _deathparticlesDuration);
        }

        Destroy(gameObject);
    }
}
