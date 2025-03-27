using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreboardUI : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject playerScorePrefab;
    [SerializeField] private GameObject roundIndicatorPrefab;
    
    [Header("Round Announcement")]
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private float rotationAmount = 15f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float displayTime = 2f;

    private Dictionary<Player, Transform> playerScoreContainers = new Dictionary<Player, Transform>();
    private Dictionary<Player, List<Image>> roundIndicators = new Dictionary<Player, List<Image>>();
    private int currentRound = 1;

    public void AddPlayerScore(Player player)
    {
        if (player == null || playerScorePrefab == null) {
            Debug.LogError("Player ou playerScorePrefab é nulo!");
            return;
        }

        // Instancia o container de score do jogador
        GameObject scoreContainer = Instantiate(playerScorePrefab, transform);
        
        // Configura o ícone do jogador
        Image playerIcon = scoreContainer.GetComponentInChildren<Image>();
        if (playerIcon != null) {
            Sprite sprite = player.GetCurrentSprite();
            if (sprite != null) {
                playerIcon.sprite = sprite;
            }
        }

        // Inicializa a lista de indicadores de rounds
        roundIndicators[player] = new List<Image>();
        playerScoreContainers[player] = scoreContainer.transform;
    }

    public void UpdateScore(Player player, int score)
    {
        if (!roundIndicators.ContainsKey(player)) return;

        // Adiciona um novo indicador de round se necessário
        if (roundIndicators[player].Count < score)
        {
            GameObject indicator = Instantiate(roundIndicatorPrefab, playerScoreContainers[player]);
            roundIndicators[player].Add(indicator.GetComponent<Image>());
        }
    }

    public void ShowRoundAnnouncement()
    {
        roundText.text = $"Round {currentRound}";
        currentRound++;
        StartCoroutine(AnimateRoundText());
    }

    private IEnumerator AnimateRoundText()
    {
        roundText.gameObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < displayTime)
        {
            float rotation = Mathf.Sin(elapsedTime * rotationSpeed) * rotationAmount;
            roundText.transform.rotation = Quaternion.Euler(0, 0, rotation);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        roundText.gameObject.SetActive(false);
    }
}
