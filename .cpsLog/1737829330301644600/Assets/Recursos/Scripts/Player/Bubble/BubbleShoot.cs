using NaughtyAttributes;
using UnityEngine;

public class BubbleShoot : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right }
    
    [SerializeField][ReadOnly][Foldout("Bubble Properties")] private Direction bubbleDirection;
}
