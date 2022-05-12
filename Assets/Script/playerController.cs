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

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";
    const string GO_TO_LEFT = "goToLeft";
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
      
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            Jump();
        }

        if (Input.GetAxis("Horizontal") < 0) // si se mueve a la izquierda 
        {
            GetComponent<SpriteRenderer>().flipX = true; // gira en el eje X el sprite
        }
        if (Input.GetAxis("Horizontal") > 0)// si se mueve a la derecha 
        {
            GetComponent<SpriteRenderer>().flipX = false; //no girar en el eje X el sprite
        }



        Debug.DrawRay(this.transform.position, Vector2.down*2f, Color.red);

    
    }

    void FixedUpdate()
    {

        move();

    }
    // script del salto del personaje
    void Jump() {
        if (IsTouchingTheGround()) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
       

    }

    // nos indica si el personaje está tocando o no el suelo
    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 2f, groundMask))
        {
            //TODO: progrmar lógica de contacto con el suelo
            return true;
        } else
        {
            //TODO: programar lógica de no contacto
            return false;
        }
    }

    void move()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed, rigidBody.velocity.y);
    }


    

 
}
