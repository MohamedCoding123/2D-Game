using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOrSecret : MonoBehaviour
{
    
    private int SecretScore = 100;

    void OnTriggerEnter2D(Collider2D coll){  //if the score is 100 then the flag take you to the secret level
                                            // otherwise, go back to level 1
        if(coll.gameObject.CompareTag("Player")){
            if(ScoreCounter.instance.currentScore >= SecretScore){
                SceneManager.LoadScene("SecretLevel");
            }
            else{
                SceneManager.LoadScene("Level 1");
            }
        }
    }


}
