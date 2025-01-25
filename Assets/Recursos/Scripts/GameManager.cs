using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed = 0.1f; // Velocidade de movimento da câmera
    [SerializeField] Transform spawnPonit; // Ponto de spawn
    [SerializeField] GameObject[] levels; // Array de níveis
    [SerializeField] private float spawnInterval = 3f; // Intervalo entre os spawns em segundos
    public bool gameHasStarted = false;

    public void StartGame()
    {
        gameHasStarted = true;
        InvokeRepeating("SpawRoom", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Movimenta a câmera ou outras lógicas podem ser colocadas aqui
    }

    public void SpawRoom()
    {
        int randomLevelIndex = Random.Range(0, levels.Length); // Escolhe um nível aleatório
        Instantiate(levels[randomLevelIndex], spawnPonit.position, Quaternion.identity); // Instancia o nível
    }


}
