using System;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    
    [SerializeField] private float initialForce = 10f;
    [SerializeField] private float verticalFloat = 0.5f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private float lifetime = 2f;
    
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        // Após o tempo determinado, a bolha estoura
        Destroy(gameObject, lifetime);
    }

    public void Movement(Vector2 direction)
    {
        _rigidbody.velocity = direction * speed;
    }
}
