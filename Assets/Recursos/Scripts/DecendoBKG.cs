using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecendoBKG : MonoBehaviour
{
    GameManager gm;
    [SerializeField] private float MoveSpeed = 0.5f; // Velocidade de movimento da câmera

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameHasStarted)
        {
            transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
        }
    }
}
