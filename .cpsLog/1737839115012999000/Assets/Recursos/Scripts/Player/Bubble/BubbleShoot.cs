using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleShoot : MonoBehaviour
{
    [SerializeField][Foldout("Definitions")] private BubbleBehavior bubblePrefab;
    [SerializeField][Foldout("Definitions")] private Transform spawnPoint;
    
    [SerializeField][Foldout("Shoot Settings")] private float fireRate = 0.5f;
    [SerializeField][Foldout("Shoot Settings")] private float fireDelay;
    
    [SerializeField][ReadOnly][Foldout("Bubble Settings")][Dropdown("GetVectorValues")] private Vector2 bubbleDirection;

    private PlayerInput _input;
    private PlayerController _controller;
    
    #region DIRECTION
    
    private DropdownList<Vector2> GetVectorValues()
    {
        return new DropdownList<Vector2>()
        {
            {"Right", Vector2.right},
            {"Left", Vector2.left},
            {"Up", Vector2.up},
            {"Down", Vector2.down},
        };
    }
    
    #endregion

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _input.actions.FindAction("Shoot").performed += OnShoot;
    }

    private void OnDisable()
    {
        _input.actions.FindAction("Shoot").performed -= OnShoot;
    }

    #region SHOOT

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!CanShoot())
            return;
        
        Debug.Log("Pew Pew");
        BubbleBehavior bubble = Instantiate(bubblePrefab, spawnPoint.position, spawnPoint.rotation);
        bubble.Movement(Vector2.right);
    }
    
    private bool CanShoot()
    {
        bool canShoot = false;
        
        if (Time.time > fireDelay)
        {
            fireDelay = Time.time + fireDelay;
            canShoot = true;
        }

        return canShoot;
    }

    #endregion
}
