using System;
using DG.Tweening;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    [SerializeField] private float initialForce = 10f;
    [SerializeField] private float verticalFloat = 0.5f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private float lifetime = 2f;
    
    private Rigidbody2D _rigidbody;

    private void Start(){
        _rigidbody.drag = drag;
        
        // Após o tempo determinado, a bolha estoura
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector2.up * verticalFloat);
    }

    public void Movement(Vector2 direction)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(direction * initialForce, ForceMode2D.Impulse);
        transform.DOScale(1f, 2f).From(0).SetEase(Ease.OutBack);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
