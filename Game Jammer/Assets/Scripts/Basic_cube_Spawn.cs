using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_cube_Spawn : MonoBehaviour
{
    [SerializeField] SOInterger cubeSpawn;

    private void Awake()
    {
        cubeSpawn.value++;  // adds to the total amount of the interger value. once it reaches the limit no planes will spawn 
    }

    private void OnDisable()
    {
        cubeSpawn.value--; // decreases the amount of planes so that another can spawn
    }

}
