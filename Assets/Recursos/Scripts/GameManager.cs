using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private Transform Levels; // Referencia ao Transform dos Levels
    [SerializeField] private float cameraMoveSpeed = 0.1f; // Velocidade de movimento da camera

    [SerializeField] Transform spawnPonit;

    [SerializeField] GameObject[] levels;

    // Update is called once per frame
    void Update()
    {
        // Movimenta o cameraHolder para cima com base na velocidade
       // Levels.position += Vector3.down * cameraMoveSpeed * Time.deltaTime;
    }

    public void SpawRoom()
    {
        int randomLevelIndex = Random.Range(0, levels.Length);
        Instantiate(levels[randomLevelIndex], spawnPonit.position, Quaternion.identity);
    }


}
