using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //variables jugador
    public float jumpForce = 4f;
    public float runningSpeed = 2f;

   

    

    private Rigidbody2D rigidBody;
   



    Animator animator;

    // variables de los boleanos

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";
    public LayerMask groundMask;

     void Awake()
    {
        
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // variables de las animaciones
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround()); // cierta cantidad de veces por cada frame verificara si el boleano es verdadero o falso
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            Jump();
        }

        if (x < 0) // si se mueve a la izquierda 
        {
            GetComponent<SpriteRenderer>().flipX = true; // gira en el eje X el sprite
        }
        else // si se mueve a la derecha 
        {
            GetComponent<SpriteRenderer>().flipX = false; //no girar en el eje X el sprite
        }



        Debug.DrawRay(this.transform.position, Vector2.down*3f, Color.red); // dibuja una linea para saber cuando el personaje toca el suelo

    
    }

    void FixedUpdate()
    {

        move();

    }
    // script del salto del personaje
    void Jump() {
        if (IsTouchingTheGround()) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // pregunta si está tocando el suelo para ejecutar el salto

            
        }
       

    }

    // nos indica si el personaje está tocando o no el suelo
    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 3f, groundMask))
        {
            //TODO: programar lógica de contacto con el suelo
            GameManager.instance.currentGameState = GameState.inGame;
            return true;
        } else
        {
            //TODO: programar lógica de no contacto
            return false;
        }
    }

    void move()
    {

        // opcion 1 

         rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed, rigidBody.velocity.y); // programa el movimiento del personaje


        //opcion 2

       // if (Input.GetKey(KeyCode.D))
       // {
       //     rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
       // }
       //
       // else if (Input.GetKey(KeyCode.A))
       // {
       //     rigidBody.velocity = Vector2.left * runningSpeed;
       // }
    }


    

 
}
