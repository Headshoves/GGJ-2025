using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleShoot : MonoBehaviour
{
    [SerializeField] [BoxGroup("Definitions")] private BubbleBehavior bubblePrefab; // Prefab da bolha
    [SerializeField] [BoxGroup("Definitions")] private Transform spawnPoint; // Ponto de spawn da bolha

    [SerializeField] [BoxGroup("Shoot Settings")] private float fireRate = 0.5f; // Taxa de disparo
    [SerializeField] [ReadOnly] [BoxGroup("Shoot Settings")] private float fireDelay; // Tempo do próximo disparo permitido

    [SerializeField] [ReadOnly] [BoxGroup("Bubble Settings")] [Dropdown("GetVectorValues")] private Vector2 bubbleDirection; // Direção da bolha

    private PlayerInput _input; // Sistema de Input
    private PlayerController _controller; // Controlador do jogador

    #region DIRECTION

    private DropdownList<Vector2> GetVectorValues()
    {
        return new DropdownList<Vector2>
        {
            { "Right", Vector2.right },
            { "Left", Vector2.left },
            { "Up", Vector2.up },
            { "Down", Vector2.down }
        };
    }

    #endregion

    private void Awake()
    {
        // Inicializa o sistema de input
        _input = GetComponent<PlayerInput>();
        if (_input == null)
        {
            Debug.LogError("PlayerInput não encontrado. Verifique se o componente PlayerInput está anexado.");
        }

        // Inicializa o controlador do jogador
        // _controller = GetComponent<PlayerController>();
        // if (_controller == null)
        // {
        //     Debug.LogError("PlayerController não encontrado. Verifique se o componente PlayerController está anexado.");
        // }
    }

    private void OnEnable()
    {
        if (_input != null)
        {
            _input.actions.FindAction("Shoot").performed += OnShoot;
        }
    }

    private void OnDisable()
    {
        if (_input != null)
        {
            _input.actions.FindAction("Shoot").performed -= OnShoot;
        }
    }

    private void Update()
    {
        // Atualiza a direção da bolha com base na direção do jogador
        if (_controller != null && _controller.PlayerDirection != Vector2.zero)
        {
            bubbleDirection = _controller.PlayerDirection.normalized;
        }
    }

    #region SHOOT

    private void OnShoot(InputAction.CallbackContext context)
    {
        // Verifica se é permitido disparar
        if (!CanShoot())
            return;

        // Validações antes de instanciar a bolha
        if (bubblePrefab == null)
        {
            Debug.LogError("BubblePrefab não atribuído. Verifique as configurações no Inspector.");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint não atribuído. Verifique as configurações no Inspector.");
            return;
        }

        // Instancia a bolha e define sua direção
        var bubble = Instantiate(bubblePrefab, spawnPoint.position, spawnPoint.rotation);
        // Define o jogador que disparou a bolha
        bubble.SetShooter = _controller;
        bubble.Movement(bubbleDirection);
    }

    private bool CanShoot()
    {
        // Verifica se o tempo atual permite um novo disparo
        if (Time.time > fireDelay)
        {
            fireDelay = Time.time + fireRate; // Atualiza o tempo do próximo disparo permitido
            return true;
        }

        return false;
    }

    #endregion
}
