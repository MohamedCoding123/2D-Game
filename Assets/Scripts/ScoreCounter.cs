using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    public static ScoreCounter instance;
    public TMP_Text coinText;
    public int currentScore = 0;
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       coinText.text = "Score: " + currentScore.ToString();
    }

    public void AddScore(int amount){ //update score counter function
        currentScore += amount;
        coinText.text = "Score: " + currentScore.ToString();
    }

}
