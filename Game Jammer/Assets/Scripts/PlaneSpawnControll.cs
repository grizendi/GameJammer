using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawnControll : MonoBehaviour
{
    [SerializeField] GameObject _planePrefab;                   // spawn the layer prefab
    [SerializeField] private float _spawnCooldown;              // cooldown that controls time between spawns
    [SerializeField] SOInterger _planeCount;                    // gets the value of the scriptable object from all spawnpoints
    [SerializeField] private int _maxPlanes;                    // sets the max amount of planes alloud to spawn 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlane", UnityEngine.Random.value * _spawnCooldown, _spawnCooldown);
    }

    // Update is called once per frame
  public void SpawnPlane()
    {
        if (_planeCount.value < _maxPlanes)
        {
            Instantiate(_planePrefab, transform.position, transform.rotation);
        }
    }
}
