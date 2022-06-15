using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    //  public Transform player;

    // Start is called before the first frame update

    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
    }

  
    // Update is called once per frame
    void Update()
    {
     //   transform.position = new Vector3(player.position.x + 10, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerController controller = collision.GetComponent<playerController>();
            GameObject player = GameObject.Find("Player");


            controller.Die();

            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 60, ForceMode2D.Impulse);
            boxCollider.enabled = false;

        }
    }
}
