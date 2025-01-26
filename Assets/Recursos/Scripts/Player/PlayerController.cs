using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField][BoxGroup("Movimentation")] private float _speed = 5;
    
    [SerializeField][BoxGroup("Jump")] private float jumpForce = 200;
    [SerializeField][BoxGroup("Jump")] private float secondJumpForceReduce = 0.8f;
    [SerializeField][BoxGroup("Jump")] private int maxJumps = 2; // Maximo de pulos (1 pulo normal + 1 pulo duplo)
    [SerializeField][BoxGroup("Jump")] private float fallingTreshold = -5f;
    
    [SerializeField][BoxGroup("Gravity")] private float lowGravityScale = 0.5f; // Gravidade reduzida para queda lenta
    private float defaultGravity;

    [SerializeField][BoxGroup("Dash")] private bool canDash = true;
    [SerializeField][BoxGroup("Dash")] private float dasshingCooldown = 1f;
    
    private bool isDashing;
    private float dashPower = 24f;
    private float dashingTime = 0.2f;

    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Animator animator;

    private Vector2 movimentInput;
    
    public bool onGround = true;
    private bool isHoldingJump; // Verifica se o jogador esta segurando o botao de pulo
    private int currentJumps; // Contador de saltos restantes

    private bool hasLanded = false;

    public Player player;

    [SerializeField] GameObject deathParticle;

    // Ao ativar o objeto, pega o PlayerInput dele e adiciona o callback do Jump e do move
    private void OnEnable(){
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }

    // Atualiza a velocidade do player de acordo com o axis gerado pelo input
    private void FixedUpdate()
    {
        if (isDashing)
            return;

        //Faz a movimentacao do personagem e a animacao
        rb.velocity = new Vector2(movimentInput.x * _speed, rb.velocity.y);
        animator.SetBool("Run", Mathf.Abs(rb.velocity.x) > 0.1f);

        // Se o jogador nao estiver no chao e estiver segurando o botao de pulo
        if (!onGround && isHoldingJump && rb.velocity.y < fallingTreshold){
            rb.gravityScale = lowGravityScale; // Aplica gravidade reduzida para cair mais devagar
        }
        else{
            rb.gravityScale = defaultGravity; // Gravidade normal quando no chao ou nao segurando o botao de pulo
        }

        animator.SetBool("IsFalling", rb.velocity.y < fallingTreshold && !onGround);
    }

    // Chamado no FixedUpdate, verifica a direcao e chama o flip
    private void Update()
    {
        if (movimentInput.x != 0) Flip();
        // Verifica o estado do ch�o para permitir o uso do segundo pulo
        if (onGround)
            currentJumps = 1; // Resetando o contador de saltos ao tocar o chao
    }

    // Metodo que coleta o vector para a movimenta��o
    public void OnMove(InputAction.CallbackContext ctx){
        movimentInput = ctx.ReadValue<Vector2>();
       // Debug.Log($"Movimento: {movimentInput}");
    }
    
    #region JUMP

    // Metodo de pulo besico, aplica uma forca no player para cima
    public void Jump(InputAction.CallbackContext ctx)
    {
        animator.SetTrigger("Jump");
        if (onGround){
            // Se o jogador estiver no ch�o, reseta o contador de pulos
            currentJumps = 1; 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (currentJumps < maxJumps){
            // Permite o segundo pulo caso o jogador ainda tenha saltos dispoiveis
            currentJumps = maxJumps;
            rb.AddForce(Vector2.up * (jumpForce * secondJumpForceReduce), ForceMode2D.Impulse);
        }
        
        // Marque que o jogador esta segurando o bota�o de pulo
        isHoldingJump = true;
    }

    // Metodo para quando o botao de pulo e solto
    public void StopHoldingJump(InputAction.CallbackContext ctx)
    {
        isHoldingJump = false;
    }

    public void OnGround(bool isGround)
    {
        onGround = isGround;
        if (isGround)
        {
           
           hasLanded = true;
            animator.SetTrigger("GroundCollision");
        }
        else if (!isGround)
        {
            hasLanded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            player.PlayeDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            player.PlayeDeath();
        }
    }

    #endregion

    #region DASH

    // Metodo de dash
    public void Dash(InputAction.CallbackContext ctx)
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
        rb.velocity = dashDirection;
        rb.gravityScale = 0f;
        tr.emitting = true;

        // Espera o tempo do dash
        yield return new WaitForSeconds(dashingTime);

        // Apos o dash, volta a velocidade normal
        isDashing = false;
        rb.gravityScale = 8f;
        tr.emitting = false;

        // Iniciar cooldown de dash
        yield return new WaitForSeconds(dasshingCooldown);
        canDash = true;
    }

    #endregion

    public void Flip()
    {
        // Inverte a escala do personagem na dire��o X
        // Inverte a escala do personagem na dire��o X
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Sign(rb.velocity.x) * Mathf.Abs(theScale.x);
        theScale.x = Mathf.Sign(rb.velocity.x) * Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }
        
}
