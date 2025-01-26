using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSelectionController : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI log;
    [SerializeField] private GameObject playerSelecion;

    [SerializeField] private GameObject intro;

    [SerializeField] GameManager gameManager;
    
    public static PlayerSelectionController Instance;
    
    private List<Player> players = new List<Player>();

    public GameObject vitoriaPopUp;

    private void Awake(){
        Instance = this;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void AddPlayer(Player player){
        players.Add(player);

        if (players.Count == PlayerInputManager.instance.playerCount){
            log.text = "Todos os players prontos, Player 1 aperte X para iniciar";
        }
    }

    public void StartGame(){
        for (int i = 0; i < players.Count; i++){
            players[i].SpawnChar();
        }
        
        playerSelecion.SetActive(false);
        gameManager.StartGame();
        

    }

    public void HideIntro()
    {
        intro.SetActive(false);
    }

    public void CheckEndGame()
    {
        int qtdActivePlayers = 0;
        Player winner = null;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].enabled)
            {
                qtdActivePlayers++;
                winner = players[i];
            }
        }

        if (qtdActivePlayers == 1)
        {
            vitoriaPopUp.SetActive(true);
            gameManager.StartCoroutine(gameManager.RestartCurrentScene());
            Debug.Log("Jogo acabou, o jogador " + winner.GetName());
        }
        else if (qtdActivePlayers == 0)
        {
            vitoriaPopUp.SetActive(true);
            gameManager.StartCoroutine(gameManager.RestartCurrentScene());
            Debug.Log("Jogo acabou, geral perdeu");
        }
    }
}
