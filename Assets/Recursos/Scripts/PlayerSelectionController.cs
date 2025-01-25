using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSelectionController : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI log;
    [SerializeField] private GameObject playerSelecion;

    [SerializeField] GameManager gameManager;
    
    public static PlayerSelectionController Instance;
    
    private List<Player> players = new List<Player>();

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
}
