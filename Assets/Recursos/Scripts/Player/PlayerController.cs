using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{ [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 200;
    [SerializeField] private float lowGravityScale = 0.5f; // Gravidade reduzida para queda lenta
    [SerializeField] private int maxJumps = 2; // M�ximo de pulos (1 pulo normal + 1 pulo duplo)

    private Vector2 movimentInput;

    [SerializeField] private bool canDash = true;
    private bool isDashing;
    private float dashPower = 24f;
    private float dashingTime = 0.2f;
    [SerializeField] private float dasshingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D _rb;
    private PlayerInput _playerInput;

    public bool onGround;
    private bool isHoldingJump; // Verifica se o jogador est� segurando o bot�o de pulo
    private bool isOnSecondJUmp;
    private int currentJumps; // Contador de saltos restantes

    // Ao ativar o objeto, pega o PlayerInput dele e adiciona o callback do Jump e do move
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions.FindAction("Jump").performed += Jump;
        _playerInput.actions.FindAction("Jump").canceled += StopHoldingJump; // Quando o bot�o � solto
        _playerInput.actions.FindAction("Dash").performed += Dash;
        _playerInput.actions.FindAction("Move").started += OnMove;
        _playerInput.actions.FindAction("Move").canceled += OnMove;
    }

    // Ao desativar o objeto, remove os callbacks
    private void OnDisable()
    {
        _playerInput.actions.FindAction("Jump").performed -= Jump;
        _playerInput.actions.FindAction("Jump").canceled -= StopHoldingJump;
        _playerInput.actions.FindAction("Dash").performed -= Dash;
        _playerInput.actions.FindAction("Move").started -= OnMove;
        _playerInput.actions.FindAction("Move").canceled -= OnMove;
    }

    // Atualiza a velocidade do player de acordo com o axis gerado pelo input
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        _rb.velocity = new Vector2(movimentInput.x * _speed, _rb.velocity.y);

        // Se o jogador n�o estiver no ch�o e estiver segurando o bot�o de pulo
        if (!onGround && isHoldingJump && isOnSecondJUmp)
        {
            _rb.gravityScale = lowGravityScale; // Aplica gravidade reduzida para cair mais devagar
        }
        else
        {
            _rb.gravityScale = 8f; // Gravidade normal quando no ch�o ou n�o segurando o bot�o de pulo
        }
    }

    // Fun��o para inverter a dire��o (flip) do personagem
    private void Flip()
    {
        // Inverte a escala do personagem na dire��o X
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Sign(_rb.velocity.x) * Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }

    // M�todo que coleta o vector para a movimenta��o
    public void OnMove(InputAction.CallbackContext ctx) => movimentInput = ctx.ReadValue<Vector2>();

    // M�todo de pulo b�sico, aplica uma for�a no player para cima
    private void Jump(InputAction.CallbackContext ctx)
    {
        if (onGround)
        {
            isOnSecondJUmp = false;
            // Se o jogador estiver no ch�o, reseta o contador de pulos
            currentJumps = 1; 
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        else if (currentJumps < maxJumps)
        {
            // Permite o segundo pulo caso o jogador ainda tenha saltos dispon�veis
            currentJumps = maxJumps;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            //mudar isso futuramente
            isOnSecondJUmp = true;
            // StartCoroutine(calculateSecondJump());
        }
        
        // Marque que o jogador est� segurando o bot�o de pulo
        isHoldingJump = true;
    }

    private IEnumerator calculateSecondJump()
    {
        yield return new WaitForSeconds(0.2f);
        isOnSecondJUmp = true;
    }

    // M�todo para quando o bot�o de pulo � solto
    private void StopHoldingJump(InputAction.CallbackContext ctx)
    {
        isHoldingJump = false;
    }

    // M�todo de dash
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
        tr.emitting = true;

        // Espera o tempo do dash
        yield return new WaitForSeconds(dashingTime);

        // Ap�s o dash, volta a velocidade normal
        isDashing = false;
        _rb.gravityScale = 8f;
        tr.emitting = false;

        // Iniciar cooldown de dash
        yield return new WaitForSeconds(dasshingCooldown);
        canDash = true;
    }

    // Chamado no FixedUpdate, verifica a dire��o e chama o flip
    private void Update()
    {
        if (movimentInput.x != 0)
        {
            Flip();
        }

        // Verifica o estado do ch�o para permitir o uso do segundo pulo
        if (onGround)
        {
            currentJumps = 1; // Resetando o contador de saltos ao tocar o ch�o
        }
    }

}
