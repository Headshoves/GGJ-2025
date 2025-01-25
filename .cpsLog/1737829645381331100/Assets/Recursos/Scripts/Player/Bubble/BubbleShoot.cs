using NaughtyAttributes;
using UnityEngine;

public class BubbleShoot : MonoBehaviour
{
    // public enum Direction { Up, Down, Left, Right }
    
    // [SerializeField][ReadOnly][Foldout("Bubble Properties")] private Direction bubbleDirection;
    
    #region DIRECTION
    
    private DropdownList<Vector2> GetVectorValues()
    {
        return new DropdownList<Vector2>()
        {
            {"Right", Vector2.right},
            {"Left", Vector2.left},
            {"Up", Vector2.up},
            {"Down", Vector2.down},
        };
    }
    
    #endregion
}
