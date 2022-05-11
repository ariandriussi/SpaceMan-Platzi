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
    const string IS_ON_DOWN = "isOnDown";
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
        animator.SetBool(IS_ON_DOWN, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) ||Input.GetMouseButtonDown(0))
        {
           Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        animator.SetBool(IS_ON_DOWN, !IsTouchingTheGround());

        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.red);

    }

    void FixedUpdate()
    {
        if (rigidBody.velocity.x < runningSpeed)
        {
            rigidBody.velocity = new Vector2(runningSpeed, //x
                                          rigidBody.velocity.y); //y
        }


    }
    // script del salto del personaje
    void Jump() {
        if(IsTouchingTheGround()) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
       

    }

    // nos indica si el personaje está tocando o no el suelo
    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask))
        {
            //TODO: progrmar lógica de contacto con el suelo
            return true;
        } else
        {
            //TODO: programar lógica de no contacto
            return false;
        }
    }

 
}
