using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    [SerializeField] private PlayerController controller;
    [SerializeField] private GameObject playerSelection;
    [SerializeField] private Personagem[] personagens;
    
    private int charIndex = 0;
    
    private PlayerInput playerInput;
    

    private void OnEnable(){
        playerSelection = Instantiate(playerSelection, GameObject.Find("PlayersContainer").transform);
        
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions.FindAction("NextChar").performed += NextChar;
        playerInput.actions.FindAction("PrevChar").performed += PrevChar;
        playerInput.actions.FindAction("Confirm").performed += ConfirmChar;
    }

    private void OnDisable(){

        playerInput.actions.FindAction("Jump").performed -= controller.Jump;
        playerInput.actions.FindAction("Jump").canceled -= controller.StopHoldingJump;
        playerInput.actions.FindAction("Dash").performed -= controller.Dash;
        playerInput.actions.FindAction("Move").started -= controller.OnMove;
        playerInput.actions.FindAction("Move").canceled -= controller.OnMove;
        
        playerInput.actions.FindAction("NextChar").performed -= NextChar;
        playerInput.actions.FindAction("PrevChar").performed -= PrevChar;
        playerInput.actions.FindAction("Confirm").performed -= ConfirmChar;
    }

    #region CHAR SELECTION

    public void NextChar(InputAction.CallbackContext context){
        charIndex++;
        if (charIndex >= personagens.Length){ charIndex = 0;}
        ShowChar();
    }

    public void PrevChar(InputAction.CallbackContext context){
        charIndex--;
        if (charIndex < 0){ charIndex = personagens.Length - 1;}
        ShowChar();
    }

    public void ConfirmChar(InputAction.CallbackContext context){
        playerInput.actions.FindAction("NextChar").performed -= NextChar;
        playerInput.actions.FindAction("PrevChar").performed -= PrevChar;
        playerInput.actions.FindAction("Confirm").performed -= ConfirmChar;
        
        GameObject personagem = Instantiate(personagens[charIndex].prefab);
        controller = personagem.GetComponent<PlayerController>();
        
        playerInput.SwitchCurrentActionMap("GamePlay");
        
        playerInput.actions.FindAction("Jump").performed += controller.Jump;
        playerInput.actions.FindAction("Jump").canceled += controller.StopHoldingJump;
        playerInput.actions.FindAction("Dash").performed += controller.Dash;
        playerInput.actions.FindAction("Move").started += controller.OnMove;
        playerInput.actions.FindAction("Move").canceled += controller.OnMove;
        
    }
    
    private void ShowChar(){
        playerSelection.GetComponent<Image>().sprite = personagens[charIndex].sprite;
    }

    #endregion
}

[Serializable]
public class Personagem{
    public string nome;
    public GameObject prefab;
    public Sprite sprite;
    public bool confirmed;
}
