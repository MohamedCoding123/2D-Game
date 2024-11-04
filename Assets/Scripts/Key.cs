using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
 
    public GameObject lockedDoor;
    public AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip keyGet; 

    void OnTriggerEnter2D(Collider2D coll){ // "unlocks" the door
        if(coll.gameObject.CompareTag("Player")){


                                            // new object to play the sound then delete itself
            GameObject audioObject = new GameObject("KeySound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = keyGet;
            audioSource.volume = 0.06f;
            audioSource.Play();

            // Destroy the audioObject after the sound finishes playing
            Destroy(audioObject, 1);

            Destroy(gameObject); //destroy the key and the locked door
            Destroy(lockedDoor);

        }
    }


}
