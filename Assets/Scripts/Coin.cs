using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Coin : MonoBehaviour
{
    [SerializeField] public int value;
    public AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip coinGet; 


    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.CompareTag("Player")){ 
            
            // make a new object that plays the sound then gets destroyed
            GameObject audioObject = new GameObject("CoinSound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = coinGet;
            audioSource.volume = 0.06f;
            audioSource.Play();

            // Destroy the audioObject after the sound finishes playing
            Destroy(audioObject, coinGet.length);
            Destroy(gameObject);
            ScoreCounter.instance.AddScore(value); //delte the coin and add the score
        }

    }
}
