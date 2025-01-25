using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    GameManager gm;
    [SerializeField] private float cameraMoveSpeed = 0.5f; // Velocidade de movimento da câmera
    [SerializeField] private float limitToDestroy;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * cameraMoveSpeed * Time.deltaTime;

        if(transform.position.y <= limitToDestroy)
        {
            gm.SpawRoom();
            Destroy(gameObject);
             
        }
    }
}
