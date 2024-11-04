using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{


    public static ColorManager Instance;
    public PlayerMovement.PlayerColor currentColor; // Store current color

    

    // Start is called before the first frame update
    void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
        
        currentColor = PlayerMovement.PlayerColor.Red; // Set initial color


    }

    public void OnColorChanged(PlayerMovement.PlayerColor newColor){

        // Find all objects of type ColorSensitiveObject and update their visibility
        var interactables = FindObjectsOfType<ColorChangingObject>();
        foreach (var interactable in interactables)
        {
            interactable.UpdateVisibility(newColor);
        }
    }


}
