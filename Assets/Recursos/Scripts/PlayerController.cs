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

    private Rigidbody2D _rb;
    private PlayerInput _playerInput;

    //Ao ativar o objeto, pega o PlayerInput dele e adiciona o callback do Jump e do move
    private void OnEnable(){
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions.FindAction("Jump").performed += Jump;
        _playerInput.actions.FindAction("Move").started += OnMove;
        _playerInput.actions.FindAction("Move").canceled += OnMove;
    }

    //Ao desativar o objeto, remove os callbacks
    private void OnDisable(){
        _playerInput.actions.FindAction("Jump").performed -= Jump;
        _playerInput.actions.FindAction("Move").started -= OnMove;
        _playerInput.actions.FindAction("Move").canceled -= OnMove;
    }

    //Atualiza a velocidade do player de acordo com o axis gerado pelo input
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(movimentInput.x * _speed, _rb.velocity.y);
    }

    //Metodo que coleta vector para a motivmentacao
    public void OnMove(InputAction.CallbackContext ctx) => movimentInput = ctx.ReadValue<Vector2>();

    //Metodo de pulo basico, aplica uma forca no player para cima
    private void Jump(InputAction.CallbackContext ctx){
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}  
