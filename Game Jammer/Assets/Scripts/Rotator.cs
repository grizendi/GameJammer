using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;


    private void Update()
    {
        transform.Rotate(0, 0, 1 * _rotateSpeed, Space.Self);
    }



}
