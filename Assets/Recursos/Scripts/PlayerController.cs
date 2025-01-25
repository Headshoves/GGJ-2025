using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 200;

    private Vector2 movimentInput;

    [SerializeField] private bool canDash = true;
    private bool isDashing;
    private float dashPower = 24f;
    private float dashingTime = 0.2f;
    private float dasshingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D _rb;
    private PlayerInput _playerInput;

    //Ao ativar o objeto, pega o PlayerInput dele e adiciona o callback do Jump e do move
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions.FindAction("Jump").performed += Jump;
        _playerInput.actions.FindAction("Dash").performed += Dash;
        _playerInput.actions.FindAction("Move").started += OnMove;
        _playerInput.actions.FindAction("Move").canceled += OnMove;
    }

    //Ao desativar o objeto, remove os callbacks
    private void OnDisable()
    {
        _playerInput.actions.FindAction("Jump").performed -= Jump;
        _playerInput.actions.FindAction("Dash").performed -= Dash;
        _playerInput.actions.FindAction("Move").started -= OnMove;
        _playerInput.actions.FindAction("Move").canceled -= OnMove;
    }

    //Atualiza a velocidade do player de acordo com o axis gerado pelo input
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        _rb.velocity = new Vector2(movimentInput.x * _speed, _rb.velocity.y);
    }

    // Função para inverter a direção (flip) do personagem
    private void Flip()
    {
        // Inverte a escala do personagem na direção X
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Sign(_rb.velocity.x) * Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }


    //Metodo que coleta vector para a motivmentacao
    public void OnMove(InputAction.CallbackContext ctx) => movimentInput = ctx.ReadValue<Vector2>();

    //Metodo de pulo basico, aplica uma forca no player para cima
    private void Jump(InputAction.CallbackContext ctx)
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    // Método de dash
    private void Dash(InputAction.CallbackContext ctx)
    {
        if (canDash && !isDashing)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    // Coroutine que gerencia o tempo do dash
    private IEnumerator DashCoroutine()
    {
        isDashing = true;

        // Ativar o dash - movendo o personagem rapidamente
        canDash = false;
        Vector2 dashDirection = new Vector2(Mathf.Sign(movimentInput.x) * dashPower, 0);
        _rb.velocity = dashDirection;
        _rb.gravityScale = 0f;

        // Espera o tempo do dash
        yield return new WaitForSeconds(dashingTime);

        // Após o dash, volta a velocidade normal
        isDashing = false;
        _rb.gravityScale = 5f;

        // Iniciar cooldown de dash
        yield return new WaitForSeconds(dasshingCooldown);
        canDash = true;
        //_rb.gravityScale = 1f;
    }

    // Chamado no FixedUpdate, verifica a direção e chama o flip
    private void Update()
    {
        if (movimentInput.x != 0)
        {
            Flip();
        }
    }
}
