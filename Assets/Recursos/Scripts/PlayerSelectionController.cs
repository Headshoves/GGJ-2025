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

    public bool isOnIntro;

    private void Awake(){
        Instance = this;
        gameManager = FindObjectOfType<GameManager>();
        isOnIntro = true;
    }

    public void AddPlayer(Player player){
        if (isOnIntro == false)
        {
            players.Add(player);

            if (players.Count == PlayerInputManager.instance.playerCount)
            {
                log.text = "Todos os players prontos, Player 1 aperte X para iniciar";
            }
        }
    }

    public void StartGame(){
        if (isOnIntro == false)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SpawnChar();
            }

            playerSelecion.SetActive(false);
            gameManager.StartGame();
        }
        

    }

    public void HideIntro()
    {
        intro.SetActive(false);
        StartCoroutine(isOnIntroChanger());
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

    IEnumerator isOnIntroChanger()
    {
        yield return new WaitForSeconds(0.5f);
        isOnIntro = false;
    }
}
