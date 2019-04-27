using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 1;       // damage dealt

    private void OnCollisionEnter(Collision other)
    {
        // check if the other object has a Health component, and Damage it, if it exists
        other.gameObject.GetComponent<Health>()?.Damage(_damage);
    }
}