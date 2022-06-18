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


    public MovementDirection direction = MovementDirection.horizontal;
    public float runningSpeed = 1.5f;

  new Rigidbody2D rigidbody;


    public bool facingRight = false;
    public bool facingUp = false;


    private Vector3 startPosition;

  

   void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startPosition;
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

}
