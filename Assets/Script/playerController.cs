using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //variables jugador
    public float jumpForce = 4f;
    public float runningSpeed = 2f;
  

   

    
    // variables componentes

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
     Animator animator;
    Vector3 startPosition;

    // variables de los boleanos

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";
    const string STATE_QUIET = "Quiet";
    const string STATE_RUNING = "Moving";
  


    // variables de las mascaras
    public LayerMask groundMask;
    

    void Awake()
    {
       
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    
        startPosition = this.transform.position;    
    }

   public void StartGame()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);

        Invoke("RestarPosition", 0.1f);
    }

    void RestarPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {

    

       

        float ejeX = Input.GetAxis("Horizontal");
        

  

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        // cierta cantidad de veces por cada frame verificara si los boleanos son verdaderos o falso



        
        if (Input.GetButtonDown("Jump"))
        {

            Jump();
        }

        if (ejeX < 0 && gameManager.instance.currentGameState == GameState.inGame) // si se mueve a la izquierda 
        {
            spriteRenderer.flipX = true; // gira en el eje X el sprite
        }
        else if (ejeX > 0 && gameManager.instance.currentGameState == GameState.inGame)// si se mueve a la derecha 
        {
            spriteRenderer.flipX = false; //no girar en el eje X el sprite
        }



        Debug.DrawRay(this.transform.position, Vector2.down*2.2f, Color.red); // dibuja una linea para saber cuando el personaje toca el suelo

    
    }

    void FixedUpdate()
    {

        move();

    }
    // script del salto del personaje
    void Jump() {
        if (IsTouchingTheGround() && gameManager.instance.currentGameState == GameState.inGame) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // pregunta si está tocando el suelo para ejecutar el salto

            
        }
       

    }


    // nos indica si el personaje está tocando o no el suelo
    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 2.2f, groundMask))
        {
            
           
            return true;
        } else
        {
           
            return false;
        }
    }




    void move()        // codigo del movimiento del player

    {

        // opcion 1 

        float isWalking = Input.GetAxis("Horizontal");

        if (isWalking != 0)
        { 

            animator.SetBool(STATE_QUIET, false);
            animator.SetBool(STATE_RUNING, true);
            rigidBody.velocity = new Vector2(isWalking * runningSpeed, rigidBody.velocity.y); // si isWalking no es igual a 0 es que el personaje se está moviendo
         
           
        }
        else
        {
            animator.SetBool(STATE_QUIET, true);
            animator.SetBool(STATE_RUNING, false);
     
        }



       


      









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


    // nos indica si el personaje a muerto

    public void Die()
    {
        animator.SetBool(STATE_ALIVE, false);
        gameManager.instance.currentGameState = GameState.gameOver;
        
    }


    

 
}
