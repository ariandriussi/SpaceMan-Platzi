using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //variables jugador
    public float jumpForce = 6f;
    private Rigidbody2D rigidBody;
    public LayerMask groundMask;

     void Awake()
    {
        
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) ||Input.GetMouseButtonDown(0))
        {
           Jump();
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
