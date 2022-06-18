using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum MovementDirection
{
    horizontal,
    vertical
}

public class enemy : MonoBehaviour


{

   public LayerMask targer;


    public MovementDirection direction = MovementDirection.horizontal;
    public float runningSpeed = 1.5f;

  new Rigidbody2D rigidbody;


    public bool facingRight = false;
    public bool facingUp = false;
    public int damageEnemy = 40;


    private Vector3 startPosition;



    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentRunningSpeed = runningSpeed;
        if (direction == MovementDirection.horizontal)
        {

            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            if (facingRight)
            {
                currentRunningSpeed = runningSpeed;
                this.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                currentRunningSpeed = -runningSpeed;
                this.transform.eulerAngles = Vector2.zero;

            }
        }

        if (direction == MovementDirection.vertical)
        {

            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            if (facingUp)
            {
                currentRunningSpeed = runningSpeed;
                this.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            else
            {
                currentRunningSpeed = -runningSpeed;
                this.transform.eulerAngles = new Vector3(0, 0, 90);

            }
        }








        if (gameManager.instance.currentGameState == GameState.inGame)
        {
            
            switch (direction)
            {
                case MovementDirection.horizontal:
                    rigidbody.velocity = new Vector2(currentRunningSpeed, rigidbody.velocity.y);
                    break;

                    case MovementDirection.vertical:
                    rigidbody.velocity = new Vector2(0, currentRunningSpeed);
                    break;

            }

          
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            facingRight = !facingRight;
            facingUp = !facingUp;


           
        }

        if (collision.tag  == "Player")
        {
            GameObject.Find("Player").GetComponent<playerController>().CollectableHealth(-damageEnemy);
        }

    }
}
