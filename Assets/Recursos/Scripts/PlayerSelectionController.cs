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

    public bool isInIntro = true;

    [SerializeField] private TextMeshProUGUI nomeVitoria;

    [SerializeField] private int roundsToWin = 3;
    private Dictionary<Player, int> playerScores = new Dictionary<Player, int>();
    public ScoreboardUI scoreboardUI;

    private void Awake(){
        Instance = this;
        gameManager = FindObjectOfType<GameManager>();
        isInIntro = true;

        if (scoreboardUI == null) {
            Debug.LogError("ScoreboardUI não está referenciado no PlayerSelectionController!");
        }
    }

    public void AddPlayer(Player player){
        if (player == null) return;
        
        players.Add(player);
        playerScores[player] = 0;
        
        if (scoreboardUI != null) {
            scoreboardUI.AddPlayerScore(player);
        }

        if (players.Count == PlayerInputManager.instance.playerCount){
            log.text = "Todos os players prontos, Player 1 aperte X para iniciar";
        }
    }

    public void StartGame(){
        StartCoroutine(StartFirstRound());
    }

    private IEnumerator StartFirstRound()
    {
        playerSelecion.SetActive(false);
        
        if (scoreboardUI != null) {
            scoreboardUI.ShowRoundAnnouncement();
        }
        
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < players.Count; i++){
            players[i].SpawnChar();
        }
        
        gameManager.StartGame();
    }

    public void HideIntro()
    {
        StartCoroutine(HideIntroChange());
        intro.SetActive(false);
    }

    IEnumerator HideIntroChange()
    {
        yield return new WaitForSeconds(0.7f);
        isInIntro = false;
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

        if (qtdActivePlayers == 1 && winner != null)
        {
            playerScores[winner]++;
            if (scoreboardUI != null) {
                scoreboardUI.UpdateScore(winner, playerScores[winner]);
            }

            if (playerScores[winner] >= roundsToWin)
            {
                // Fim do jogo
                vitoriaPopUp.SetActive(true);
                gameManager.StartCoroutine(gameManager.RestartCurrentScene());
                nomeVitoria.text = winner.GetName();
            }
            else
            {
                // Próxima rodada
                StartCoroutine(StartNewRound());
            }
        }
        else if (qtdActivePlayers == 0)
        {
            vitoriaPopUp.SetActive(true);
            nomeVitoria.text = "Ninguem";
            gameManager.StartCoroutine(gameManager.RestartCurrentScene());
        }
    }

    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(1f);
        
        scoreboardUI.ShowRoundAnnouncement();
        
        yield return new WaitForSeconds(2f);
        
        // Reativa todos os jogadores
        foreach (Player player in players)
        {
            player.enabled = true;
            player.SpawnChar();
        }
        
        // Reinicia o nível
        gameManager.StartGame();
    }
}
