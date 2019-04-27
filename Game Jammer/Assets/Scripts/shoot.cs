using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
   private MachineGun _gun;

    private void Start()
    {
        _gun = GetComponentInChildren<MachineGun>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1_P1"))
        {
            _gun.TryFire();
        }

    }
}
