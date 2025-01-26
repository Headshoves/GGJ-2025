using NaughtyAttributes;
using UnityEngine;

public class BubbleShoot : MonoBehaviour
{
    [SerializeField][ReadOnly][Foldout("Bubble Properties")][Dropdown("GetVectorValues")] private Vector2 bubbleDirection;
    
    #region BUBBLE DIRECTION
    
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

    #region MyRegion

    

    #endregion
}
