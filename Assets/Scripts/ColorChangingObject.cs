using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingObject : MonoBehaviour
{
    
    public PlayerMovement.PlayerColor objectColor; // the color associated with the object
    private SpriteRenderer spriteRenderer; // Reference to control visual appearance
    private Collider2D objectCollider; // Reference to control collision

    
    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();

    }

    void Start(){
        // Set initial visibility based on the current color in ColorManager
        UpdateVisibility(ColorManager.Instance.currentColor);
    }
    
    


    public void UpdateVisibility(PlayerMovement.PlayerColor currentColor)
    {
        // Enable object only if its color matches the player's color
        bool isActive = currentColor == objectColor;
        spriteRenderer.enabled = isActive; 
        objectCollider.enabled = isActive;
    }
}
