using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionController : MonoBehaviour
{
    private List<Personagem> players = new List<Personagem>();

    public static PlayerSelectionController Instance;

    private void Awake(){
        Instance = this;
    }
}
