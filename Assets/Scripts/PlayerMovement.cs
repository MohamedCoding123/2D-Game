using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] public float speed; //left/right speed
    public Rigidbody2D rb;
    private Animator animator;

    private bool Grounded;


    public enum PlayerColor{ //2 colors
        Green,
        Red
    }
    public PlayerColor currentColor = PlayerColor.Red; //start color
    private SpriteRenderer spriteRenderer;  //so we can change the player color



    public AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip jumpSound;      // Audio clip for jumping
    public AudioClip spikeDeathSound;     // Audio clip for dying
    public AudioClip fallDeathSound; // Audio clip for falling off map
    
    void Awake()
    {
        //get references
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdatePlayerColor(); // initial color
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //use keys to move
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y); // horizontal speed

        if(horizontalInput > 0.01f){
            transform.localScale = new Vector3(0.6f, .6f, 1); //face right
        }
        if(horizontalInput < -0.01f){ 
            transform.localScale = new Vector3(-0.6f, 0.6f, 1); //face left
        }

        if(transform.position.y < -4f){
            audioSource.PlayOneShot(fallDeathSound, 0.142f);
            if(transform.position.y < -10f){
                Die();
            }
        }


        if(Input.GetKey(KeyCode.Space) && Grounded){    //jump when space is pressed
            jump(); 
        }

        if (Input.GetKeyDown(KeyCode.Return)){
            ToggleColor();
        }

        animator.SetBool("Run", horizontalInput !=0); //sets run boolean to true/false by checking if idle
        animator.SetBool("Grounded", Grounded); //sets animator Grounded boolean to true/false by checking if not grounded
    }


    void jump(){
        audioSource.PlayOneShot(jumpSound, 0.13f);
        rb.velocity = new Vector2(rb.velocity.x, 6);  //jump
        animator.SetTrigger("Jump");
        Grounded = false;
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){   // if on the grounded the boolean is true
            Grounded = true;
        }

        if(collision.gameObject.tag == "Trap"){ // if hit by trap
            audioSource.PlayOneShot(spikeDeathSound, 0.142f); 
            Die();
        }

    }

    void Die(){
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(-8, -3.2f, 0); // reset position
    }
    

    void UpdatePlayerColor(){ //visual color update
        switch(currentColor){
            case PlayerColor.Green:
                spriteRenderer.color = Color.green;
                break;
            case PlayerColor.Red:
                spriteRenderer.color = new Color(0.86f, 0.25f, 0.25f); // I like this color of red specifically lol
                break;
        }
    }





    void ToggleColor(){ // update color in code
        if(currentColor == PlayerColor.Green){
            currentColor = PlayerColor.Red;
        }
        else{
            currentColor = PlayerColor.Green;
        }
        UpdatePlayerColor(); //update color
        ColorManager.Instance.OnColorChanged(currentColor); // Notify other objects of color change
    }

 
}
