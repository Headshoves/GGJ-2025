using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleShoot : MonoBehaviour
{
    [SerializeField][Foldout("Definitions")] private BubbleBehavior bubblePrefab;
    [SerializeField][Foldout("Definitions")] private Transform spawnPoint;
    
    [SerializeField][Foldout("Shoot Settings")] private float fireRate;
    [SerializeField][Foldout("Shoot Settings")] private float fireDelay;
    
    [SerializeField][ReadOnly][Foldout("Bubble Settings")][Dropdown("GetVectorValues")] private Vector2 bubbleDirection;

    private PlayerInput _input;
    
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

    private void OnEnable()
    {
        _input = GetComponent<PlayerInput>();

        _input.actions.FindAction("Shoot").performed += ShootBubble;
    }

    private void OnDisable()
    {
        _input.actions.FindAction("Shoot").performed -= ShootBubble;
    }

    #region SHOOT

    private void ShootBubble(InputAction.CallbackContext context)
    {
        if (!CanShoot())
            return;
        
        
    }
    
    private bool CanShoot()
    {
        
    }

    #endregion
}
