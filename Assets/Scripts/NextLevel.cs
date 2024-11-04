using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D coll){ //flag on level one send player to level 2
    if(coll.CompareTag("Player")){

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
    } 
  }
}
