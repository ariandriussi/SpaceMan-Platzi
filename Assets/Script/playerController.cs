using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //variables jugador
    public float jumpForce = 4f;
    public float runningSpeed = 50f;
    public float raycast = 2.2f;





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

    int healthPoints, manaPoints;

    public const int INITIAL_HEALTH = 100, INITIAL_MANA = 15, MAX_HEALTH = 200, MAX_MANA = 30, MIN_HEALTH = 10, MIN_MANA = 0;

    public const int RUNNING_COST = 1;
    public float RUNNING_FORCE = 2f;

    // variables de las mascaras
    public LayerMask groundMask;
    public LayerMask idleMask;

    CapsuleCollider2D coliderCapsule;

    BoxCollider2D boxCollider;
    public AudioSource gameOver;






    void Awake()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coliderCapsule = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameOver = GetComponent<AudioSource>();
        
    }

    void Start()
    {


        startPosition = this.transform.position;
        coliderCapsule.enabled = true;
        boxCollider.enabled = false;



    }


    public void StartGame()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);

        coliderCapsule.enabled = true;
        boxCollider.enabled = false;

        healthPoints = INITIAL_HEALTH;
        manaPoints = INITIAL_MANA;

        Invoke("RestarPosition", 0.1f);



    }

    void RestarPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CamareFollow>().ResetCameraPosition();


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



        Debug.DrawRay(this.transform.position, Vector2.down * raycast, Color.red); // dibuja una linea para saber cuando el personaje toca el suelo




    }

    void FixedUpdate()
    {
        if (gameManager.instance.currentGameState == GameState.inGame)
        {
            move(false);

        }

        if (Input.GetButton("SuperRunning"))
        {
            move(true);
        }


    }
    // script del salto del personaje
    void Jump() {
        if (IsTouchingTheGround() && gameManager.instance.currentGameState == GameState.inGame) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // pregunta si está tocando el suelo para ejecutar el salto
            GetComponent<AudioSource>().Play();


        }


    }


    // nos indica si el personaje está tocando o no el suelo
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, raycast, groundMask))
        {


            return true;
        } else
        {

            return false;
        }
    }




    
  



    void move(bool superRunning)        // codigo del movimiento del player

    {
        float runningSpeedFactor = runningSpeed;
        
        // opcion 1 

       if (superRunning && manaPoints >= RUNNING_COST)
        {
            manaPoints -= RUNNING_COST;
            runningSpeedFactor *= RUNNING_FORCE;
        }




        float isWalking = Input.GetAxis("Horizontal");


        if (isWalking != 0)
        { 

            animator.SetBool(STATE_QUIET, false);
            animator.SetBool(STATE_RUNING, true);
            rigidBody.velocity = new Vector2(isWalking * runningSpeedFactor, rigidBody.velocity.y); // si isWalking no es igual a 0 es que el personaje se está moviendo
         
           
        }
        else 
        {
            animator.SetBool(STATE_QUIET, true);
            animator.SetBool(STATE_RUNING, false);
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
     
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
        float travelledDistance = GetTravelledDistance();
        float previousMaxDistance = PlayerPrefs.GetFloat("maxscore", 0f);
   
       

        if (travelledDistance > previousMaxDistance)
        {
            PlayerPrefs.SetFloat("maxscore", travelledDistance);
        }
        animator.SetBool(STATE_ALIVE, false);
        gameManager.instance.currentGameState = GameState.gameOver;
        coliderCapsule.enabled = false;
        boxCollider.enabled = true;


        Invoke("DiedMenu", 2f);

       


    }

    void DiedMenu()
    {
        Time.timeScale = 0f;
        MenuManager.instance.ShowDeadMenu();
        MenuManager.instance.HideGameMenu();

    }

    public void CollectableHealth(int points)
    {
        this.healthPoints += points;

        if (healthPoints >= MAX_HEALTH)
        {
            healthPoints = MAX_HEALTH;
        }

        if (healthPoints <= 0)
        {
            Die();
            healthPoints = INITIAL_HEALTH;
        }
    }

    public void CollectableMana(int points)
    {
        this.manaPoints += points;

        if (manaPoints >= MAX_MANA)
        {
            manaPoints = MAX_MANA;
        }
    }

    public int GetHealth()
    {
        return healthPoints;
    }

    public int GetMana()
    {
        return manaPoints;
    }


    public float GetTravelledDistance()
    {
        return this.transform.position.x - startPosition.x;
    }
    
    
 
}
