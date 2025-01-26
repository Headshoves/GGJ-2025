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
    private bool confirmed;
    
    private PlayerInput playerInput;
    

    private void OnEnable(){
        playerSelection = Instantiate(playerSelection, GameObject.Find("PlayersContainer").transform);
        PlayerSelectionController.Instance.HideIntro();

        playerInput = GetComponent<PlayerInput>();

        playerInput.actions.FindAction("NextChar").performed += NextChar;
        playerInput.actions.FindAction("PrevChar").performed += PrevChar;
        playerInput.actions.FindAction("Confirm").performed += ConfirmChar;
        
        
    }

    private void OnDisable(){

        if (controller != null){
            playerInput.actions.FindAction("Jump").performed -= controller.Jump;
            playerInput.actions.FindAction("Jump").canceled -= controller.StopHoldingJump;
            playerInput.actions.FindAction("Dash").performed -= controller.Dash;
            playerInput.actions.FindAction("Move").performed -= controller.OnMove;
            playerInput.actions.FindAction("Move").canceled -= controller.OnMove;
            controller.gameObject.SetActive(false);
        }
        
        playerInput.actions.FindAction("NextChar").performed -= NextChar;
        playerInput.actions.FindAction("PrevChar").performed -= PrevChar;
        playerInput.actions.FindAction("Confirm").performed -= ConfirmChar;
    }

    #region CHAR SELECTION

    public void NextChar(InputAction.CallbackContext context){
        if (!confirmed){
            charIndex++;
            if (charIndex >= personagens.Length){ charIndex = 0;}
            ShowChar();
        }
    }

    public void PrevChar(InputAction.CallbackContext context){
        if (!confirmed){
            charIndex--;
            if (charIndex < 0){ charIndex = personagens.Length - 1;}
            ShowChar();
        }
    }

    public void ConfirmChar(InputAction.CallbackContext context){
        if (!confirmed && PlayerSelectionController.Instance.isOnIntro == false){
            playerSelection.GetComponent<Image>().color = Color.green;

            if (playerInput.user.index != 0){
                playerInput.actions.FindAction("NextChar").performed -= NextChar;
                playerInput.actions.FindAction("PrevChar").performed -= PrevChar;
                playerInput.actions.FindAction("Confirm").performed -= ConfirmChar;
            }

            PlayerSelectionController.Instance.AddPlayer(this);
            
            confirmed = true;
        }
        else if(confirmed && playerInput.user.index == 0){
            PlayerSelectionController.Instance.StartGame();
        }
    }
    
    private void ShowChar(){
        playerSelection.GetComponent<Image>().sprite = personagens[charIndex].sprite;
    }

    #endregion

    public void SpawnChar(){
        GameObject personagem = Instantiate(personagens[charIndex].prefab);
        controller = personagem.GetComponent<PlayerController>();
        controller.player = this;

        playerInput.SwitchCurrentActionMap("GamePlay");

        playerInput.actions.FindAction("Jump").performed += controller.Jump;
        playerInput.actions.FindAction("Jump").canceled += controller.StopHoldingJump;
        playerInput.actions.FindAction("Dash").performed += controller.Dash;
        playerInput.actions.FindAction("Move").performed += controller.OnMove;
        playerInput.actions.FindAction("Move").canceled += controller.OnMove;
    }


    public void PlayeDeath()
    {
        this.enabled = false;
        PlayerSelectionController.Instance.CheckEndGame();
    }

    public string GetName()
    {
        return personagens[charIndex].nome;
    }

}

[Serializable]
public class Personagem{
    public string nome;
    public GameObject prefab;
    public Sprite sprite;
}
