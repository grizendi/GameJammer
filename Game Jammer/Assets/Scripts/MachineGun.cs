using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    [SerializeField] protected GameObject _bullet;      // the projectile fired
    [SerializeField] private float _shotCooldown = 0.25f;       // time between shots 

    private float _lastshotTime; // the time from last shot

    //attempt to fire the weapon
    public void TryFire()
    {
        if (Time.timeSinceLevelLoad >= _lastshotTime + _shotCooldown)
        {
            _lastshotTime = Time.timeSinceLevelLoad;
            Fire();
        }
    }

    // fire the weapon
    protected virtual void Fire()
    {
        Instantiate(_bullet, transform.position, transform.rotation);
    }
}
