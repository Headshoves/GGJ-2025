using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.OnGround(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.OnGround(false);
    }
}
