using System;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 2f;

    private void OnEnable()
    {
        // Após o tempo determinado, a bolha 
        Destroy(gameObject, lifetime);
    }
}
